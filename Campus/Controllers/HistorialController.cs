using Microsoft.AspNetCore.Mvc;

namespace Campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        public HistorialController()
        {
            
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            Console.WriteLine("Llegó una petición al servicio Campus.");
            return Ok("Respuesta exitosa desde el controlador Historial.");
        }
    }
}
