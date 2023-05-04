using AutoMapper;
using Centralizador2023.ComunicacionAsync;
using Centralizador2023.ComunicacionSync.http;
using Centralizador2023.DTO;
using Centralizador2023.Models;
using Centralizador2023.Repositorios;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Centralizador2023.Controllers
{
    [ApiController]
    [Route("api/estudiante")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository estRepo;
        private readonly IMapper mapper;
        private readonly ICampusHistorialCliente campusHistorialCliente;
        private readonly IBusDeMensajesCliente busDeMensajesCliente;

        public EstudianteController(IEstudianteRepository repo, IMapper mapper, ICampusHistorialCliente campusHistorialCliente, IBusDeMensajesCliente busDeMensajesCliente)
        {
            estRepo = repo;
            this.mapper = mapper;
            this.campusHistorialCliente = campusHistorialCliente;
            this.busDeMensajesCliente = busDeMensajesCliente;
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
        public async Task<ActionResult<EstudianteReadDTO>> setestudiantes(EstudianteCreateDTO estCreateDTO)
        {
            Estudiante estudiante = mapper.Map<Estudiante>(estCreateDTO);
            estRepo.AddEstudiante(estudiante);
            estRepo.Guardar();
            EstudianteReadDTO estRetorno = mapper.Map<EstudianteReadDTO>(estudiante);

            try {
                await campusHistorialCliente.ComunicarseConCampus(estRetorno);
            } catch (Exception e) {
                Console.WriteLine($"Ocurrió un error al comunicarse con Campus de forma sincronizada: {e.Message}");
            }

            try {
                var estudiantePublisherDTO = mapper.Map<EstudiantePublisherDTO>(estRetorno);
                estudiantePublisherDTO.tipoEvento = "estudiante_publicado";
                busDeMensajesCliente.PublicarNuevoEstudiante(estudiantePublisherDTO);
            } catch (Exception e) {
                Console.WriteLine($"Ocurrió un error al tratar de publicar: {e.Message}");
            }

            return CreatedAtRoute(nameof(getestudiante), new { ci = estRetorno.ci }, estRetorno);
        }
        [HttpPut("{ci}")]
        public ActionResult updateestudiante(int ci, EstudianteUpdateDTO estUpdateDTO)
        {
            Estudiante estudiante = estRepo.GetEstudianteByCi(ci);
            if (estudiante == null)
                return NotFound();
            mapper.Map(estUpdateDTO, estudiante);//Hasta acá ya se está efectuando el update
            estRepo.UpdateEstudiante(estudiante);
            estRepo.Guardar();
            return NoContent();
        }
        [HttpPatch("{ci}")]
        public ActionResult updateparcialestudiante(int ci, JsonPatchDocument<EstudianteUpdateDTO> estPatch)
        {
            Estudiante estudiante = estRepo.GetEstudianteByCi(ci);
            if (estudiante == null)
                return NotFound();
            EstudianteUpdateDTO estParaPatch = mapper.Map<EstudianteUpdateDTO>(estudiante);
            estPatch.ApplyTo(estParaPatch, ModelState);
            if (!TryValidateModel(estParaPatch))
                return ValidationProblem(ModelState);

            mapper.Map(estParaPatch, estudiante);//Hasta acá ya se está efectuando el update
            estRepo.UpdateEstudiante(estudiante);
            estRepo.Guardar();
            return NoContent();
        }
        [HttpDelete("{ci}")]
        public ActionResult eliminarestudiante(int ci)
        {
            Estudiante estudiante = estRepo.GetEstudianteByCi(ci);
            if (estudiante == null)
                return NotFound();
            estRepo.ElimanrEstudiante(estudiante);
            estRepo.Guardar();
            return NoContent();
        }
    }
}
