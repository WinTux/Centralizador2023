using Centralizador2023.Models;

namespace Centralizador2023.Repositorios
{
    public class ImplEstudianteRepository : IEstudianteRepository
    {
        private readonly InstitutoXDbContext cont;
        public ImplEstudianteRepository(InstitutoXDbContext contexto)
        {
            cont = contexto;
        }
        public Estudiante GetEstudianteByCi(int ci)
        {
            return cont.Estudiantes.FirstOrDefault(est => est.ci == ci);
        }

        public IEnumerable<Estudiante> GetEstudiantes()
        {
            return cont.Estudiantes.ToList();
        }
    }
}
