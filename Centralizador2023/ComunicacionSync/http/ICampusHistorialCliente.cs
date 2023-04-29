using Centralizador2023.DTO;

namespace Centralizador2023.ComunicacionSync.http
{
    public interface ICampusHistorialCliente
    {
        Task ComunicarseConCampus(EstudianteReadDTO est);
    }
}
