using Centralizador2023.Models;

namespace Centralizador2023.Repositorios
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Estudiante GetEstudianteByCi(int ci);
    }
}
