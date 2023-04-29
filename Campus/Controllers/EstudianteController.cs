using AutoMapper;
using Campus.Conexion;
using Campus.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Campus.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudianteController :ControllerBase
    {
        private readonly IPerfilRepository repositorio;
        private readonly IMapper mapper;
        public EstudianteController(IPerfilRepository repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EstudianteReadDTO>> GetEstudiantes() {
            Console.WriteLine("Se obtienen estudiantes (mediante servicio Campus)");
            var estudiantes = repositorio.GetEstudiantes();
            return Ok(mapper.Map<IEnumerable<EstudianteReadDTO>>(estudiantes));
        }
    }
}
