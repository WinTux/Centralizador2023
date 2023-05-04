using AutoMapper;
using Campus.DTO;
using Campus.Models;

namespace Campus.DTO_Perfiles
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<Estudiante, EstudianteReadDTO>();
            CreateMap<Perfil, PerfilReadDTO>();
            CreateMap<PerfilCreateDTO, Perfil>();
            CreateMap<EstudiantePublisherDTO, Estudiante>().ForMember(destino => destino.fci, opcion => opcion.MapFrom(fuente => fuente.ci));
        }
    }
}
