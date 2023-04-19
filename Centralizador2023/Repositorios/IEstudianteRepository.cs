using Centralizador2023.Models;

namespace Centralizador2023.Repositorios
{
    public interface IEstudianteRepository
    {
        IEnumerable<Estudiante> GetEstudiantes();
        Estudiante GetEstudianteByCi(int ci);
        void AddEstudiante(Estudiante est);
        bool Guardar();
        void UpdateEstudiante(Estudiante est);
        void ElimanrEstudiante(Estudiante est);
    }
}
