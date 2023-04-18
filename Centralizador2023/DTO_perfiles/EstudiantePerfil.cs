using AutoMapper;
using Centralizador2023.DTO;
using Centralizador2023.Models;

namespace Centralizador2023.DTO_perfiles
{
    public class EstudiantePerfil : Profile
    {
        public EstudiantePerfil()
        {
            CreateMap<Estudiante,EstudianteReadDTO>();// -->
            CreateMap<EstudianteCreateDTO, Estudiante> ();// -->
            CreateMap<EstudianteUpdateDTO, Estudiante>();// -->
        }
    }
}
