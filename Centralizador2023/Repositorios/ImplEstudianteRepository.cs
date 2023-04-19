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

        public void AddEstudiante(Estudiante est)
        {
            if (est == null)
                throw new ArgumentNullException(nameof(est));
            cont.Estudiantes.Add(est);
        }

        public void ElimanrEstudiante(Estudiante est)
        {
            //Continuar!!
        }

        public Estudiante GetEstudianteByCi(int ci)
        {
            return cont.Estudiantes.FirstOrDefault(est => est.ci == ci);
        }

        public IEnumerable<Estudiante> GetEstudiantes()
        {
            return cont.Estudiantes.ToList();
        }

        public bool Guardar()
        {
            return (cont.SaveChanges() > -1);
        }

        public void UpdateEstudiante(Estudiante est)
        {
            //No hacemos nada
        }
    }
}
