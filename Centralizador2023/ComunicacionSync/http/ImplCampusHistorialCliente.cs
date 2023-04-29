using Centralizador2023.DTO;
using System.Text;
using System.Text.Json;

namespace Centralizador2023.ComunicacionSync.http
{
    public class ImplCampusHistorialCliente : ICampusHistorialCliente
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public ImplCampusHistorialCliente(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }
        public async Task ComunicarseConCampus(EstudianteReadDTO est)
        {
            StringContent cuerpoHttp = new StringContent(JsonSerializer.Serialize(est),Encoding.UTF8,"application/json");
            var respuesta = await httpClient.PostAsync($"{configuration["CampusService"]}/api/Historial", cuerpoHttp);
            if (respuesta.IsSuccessStatusCode)
                Console.WriteLine("Envío de POST sincronizado hacia el servicoo Campus tuvo éxito.");
            else
                Console.WriteLine("Envío de POST sincronizado hacia el servicoo Campus NO tuvo éxito.");
        }
    }
}
