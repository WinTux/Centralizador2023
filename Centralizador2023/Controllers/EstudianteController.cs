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
        public ActionResult<IEnumerable<Estudiante>> getestudiantes()
        {
            var ests = estRepo.GetEstudiantes();//Modificar con DTO
            return Ok(ests);
        }
        [HttpGet("{ci}")]
        public ActionResult<Estudiante> getestudiante(int ci)
        {
            Estudiante est = estRepo.GetEstudianteByCi(ci);
            if(est != null)
                return Ok(mapper.Map<EstudianteReadDTO>(est));
            return NotFound();
        }
    }
}
