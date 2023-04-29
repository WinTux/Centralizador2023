using AutoMapper;
using Campus.Conexion;
using Campus.DTO;
using Campus.Models;
using Microsoft.AspNetCore.Mvc;

namespace Campus.Controllers
{
    [Route("api/perfil/estudiante/{estudianteci}")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository repositorio;
        private readonly IMapper mapper;
        public PerfilController(IPerfilRepository repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PerfilReadDTO>> GetPerfilesDeEstudiante(int estudianteci)
        {
            Console.WriteLine($"Se obtienen perfiles del estudiante de CI: {estudianteci}");
            if (!repositorio.ExisteEstudiante(estudianteci))
                return NotFound();
            var perfiles = repositorio.GetPerfilesDeEstudiante(estudianteci);
            return Ok(mapper.Map<IEnumerable<PerfilReadDTO>>(perfiles));
        }
        [HttpGet("{perfilid}", Name = "GetPerfilDeEstudiante")] //http://localhost:1234/api/perfil/estudiante/123/333
        public ActionResult<PerfilReadDTO> GetPerfilDeEstudiante(int estudianteci, int perfilid)
        {
            Console.WriteLine($"Se obtiene perfil {perfilid} del estudiante de CI: {estudianteci}");
            if (!repositorio.ExisteEstudiante(estudianteci))
                return NotFound();
            var perfil = repositorio.GetPerfil(perfilid, estudianteci);
            if(perfil == null)
                return NotFound();
            return Ok(mapper.Map<PerfilReadDTO>(perfil));
        }
        [HttpPost]
        public ActionResult<PerfilReadDTO> CrearPerfilParaEstudiante(int estudianteci, PerfilCreateDTO perfilDTO)
        {
            Console.WriteLine($"Se crea perfil para estudiante de CI: {estudianteci}");
            if (!repositorio.ExisteEstudiante(estudianteci))
                return NotFound();
            Perfil perfil = mapper.Map<Perfil>(perfilDTO);
            repositorio.CrearPerfil(estudianteci, perfil);
            repositorio.Guardar();
            var perfilReadDTO = mapper.Map<PerfilReadDTO>(perfil);
            return CreatedAtRoute(nameof(GetPerfilDeEstudiante), new { estudianteci = estudianteci, perfilid = perfilReadDTO.id}, perfilReadDTO);
        }
    }
}
