using Centralizador2023.Models;
using Centralizador2023.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Centralizador2023.Controllers
{
    [ApiController]
    [Route("api/programador")]
    public class ProgramadorController : ControllerBase
    {
        private readonly ImplProgramadorRepository repo = new ImplProgramadorRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Programador>> GetProgramadores() {
            var programadores = repo.GetProgramadores();
            return Ok(programadores);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Programador>> GetProgramadorById(int id)
        {
            var programador = repo.GetProgramadorById(id);
            return Ok(programador);
        }
    }
}
