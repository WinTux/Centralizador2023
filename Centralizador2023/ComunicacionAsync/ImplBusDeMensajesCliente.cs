using Centralizador2023.DTO;
using System.Text.Json;
using RabbitMQ.Client;
using System.Text;

namespace Centralizador2023.ComunicacionAsync
{
    public class ImplBusDeMensajesCliente : IBusDeMensajesCliente
    {
        private readonly IConfiguration configuration;
        private readonly IConnection connection;
        private readonly IModel canal;
        public ImplBusDeMensajesCliente(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionFactory factory = new ConnectionFactory() {
                HostName = configuration["Host_RabbitMQ"],
                Port = int.Parse(configuration["Puerto_RabbitMQ"])
            };
            try {
                connection = factory.CreateConnection();
                canal = connection.CreateModel();
                canal.ExchangeDeclare(
                    exchange: "mi_exchange",
                    type: ExchangeType.Fanout
                    );

                //Opcionalmente podemos agregar un trigger de evento shutdown (para que se ejecute el método definido opcionalmente)
                connection.ConnectionShutdown += RabbitMQ_evento_shutdown;
            } catch (Exception e) {
                Console.WriteLine($"Error al tratar de establecer una conexión con RabbitMQ: {e.Message}");
            }
        }

        //este bloque nos puede servir, es completamente opcional
        public void RabbitMQ_evento_shutdown(object sender, ShutdownEventArgs args) {
            Console.WriteLine("Se desconecta de RabbitMQ y algo podría ejecutarse acá");
        }

        public void PublicarNuevoEstudiante(EstudiantePublisherDTO estudiantePublisherDTO)
        {
            string mensaje = JsonSerializer.Serialize(estudiantePublisherDTO);
            if (connection.IsOpen)
                Enviar(mensaje);
            else
                Console.WriteLine("No se pudo enviar el mensaje al bus de mensajes RabbitMQ");
        }

        private void Enviar(string mensaje)
        {
            var cuerpo = Encoding.UTF8.GetBytes(mensaje);
            canal.BasicPublish(
                exchange: "mi_exchange",
                routingKey: "",
                basicProperties: null,
                body: cuerpo
                );
            Console.WriteLine("Se envió el mensaje al bus de mensajes");
        }

        private void Finalizar() {
            if (canal.IsOpen) {
                canal.Close();
                connection.Close();
            }
        }
    }
}
