using AutoMapper;
using Centralizador2023.DTO;
using Centralizador2023.Models;
using Centralizador2023.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Centralizador2023.Controllers
{
    [ApiController]
    [Route("api/estudiante")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository estRepo;
        private readonly IMapper mapper;

        public EstudianteController(IEstudianteRepository repo, IMapper mapper)
        {
            estRepo = repo;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EstudianteReadDTO>> getestudiantes()
        {
            var ests = estRepo.GetEstudiantes();
            return Ok(mapper.Map<IEnumerable<EstudianteReadDTO>>(ests));
        }
        [HttpGet("{ci}", Name = "getestudiante")]
        public ActionResult<EstudianteReadDTO> getestudiante(int ci)
        {
            Estudiante est = estRepo.GetEstudianteByCi(ci);
            if(est != null)
                return Ok(mapper.Map<EstudianteReadDTO>(est));
            return NotFound();
        }
        [HttpPost]
        public ActionResult<EstudianteReadDTO> setestudiantes(EstudianteCreateDTO estCreateDTO)
        {
            Estudiante estudiante = mapper.Map<Estudiante>(estCreateDTO);
            estRepo.AddEstudiante(estudiante);
            estRepo.Guardar();
            EstudianteReadDTO estRetorno = mapper.Map<EstudianteReadDTO>(estudiante);
            return CreatedAtRoute(nameof(getestudiante), new { ci = estRetorno.ci }, estRetorno);
        }
    }
}
