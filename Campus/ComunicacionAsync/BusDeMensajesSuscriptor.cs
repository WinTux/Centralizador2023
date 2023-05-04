using Campus.Eventos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Campus.ComunicacionAsync
{
    public class BusDeMensajesSuscriptor : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly IProcesadorDeEventos procesadorDeEventos;
        private IConnection conexion;
        private IModel canal;
        private string cola;
        public BusDeMensajesSuscriptor(IConfiguration configuration, IProcesadorDeEventos procesadorDeEventos)
        {
            this.configuration = configuration;
            this.procesadorDeEventos = procesadorDeEventos;
            InicialrRabbitMQ();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();//detener si se lo solicita
            var consumidor = new EventingBasicConsumer(canal);
            consumidor.Received += (modulo, eveARgs) => {
                Console.WriteLine("Un evento sucedió");
                var cuerpo = eveARgs.Body;
                var mensaje = Encoding.UTF8.GetString(cuerpo.ToArray());
                procesadorDeEventos.ProcesarEvento(mensaje);
            };
            canal.BasicConsume(
                    queue: cola,
                    autoAck: true,
                    consumer: consumidor
                    );
            return Task.CompletedTask;
        }
        private void InicialrRabbitMQ() {
            var factory = new ConnectionFactory()
            {
                HostName = configuration["Host_RabbitMQ"],
                Port = int.Parse(configuration["Puerto_RabbitMQ"])
            };
            conexion = factory.CreateConnection();
            canal = conexion.CreateModel();
            canal.ExchangeDeclare(
                exchange: "mi_exchange",
                type: ExchangeType.Fanout
                );
            cola = canal.QueueDeclare().QueueName;
            canal.QueueBind(
                queue: cola,
                exchange: "mi_exchange",
                routingKey: ""
                );
        }
        public override void Dispose()
        {
            if (canal.IsOpen)
            {
                canal.Close();
                conexion.Close();
            }
            base.Dispose();
        }

    }

    
}
