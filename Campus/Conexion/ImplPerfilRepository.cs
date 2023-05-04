using Campus.Models;

namespace Campus.Conexion
{
    public class ImplPerfilRepository : IPerfilRepository
    {
        private readonly CampusDbContext contexto;

        public ImplPerfilRepository(CampusDbContext contexto)
        {
            this.contexto = contexto;
        }
        public void CrearEstudiante(Estudiante est)
        {
            if (est == null)
                throw new ArgumentNullException(nameof(est));
            else
                contexto.Estudiantes.Add(est);
        }

        public void CrearPerfil(int ci, Perfil per)
        {
            if(per == null)
                throw new ArgumentNullException(nameof(per));
            else
            {
                per.estudianteCI = ci;
                contexto.Perfiles.Add(per);
            }
                
        }

        public bool ExisteEstudiante(int ci)
        {
            return contexto.Estudiantes.Any(est => est.ci == ci);
        }

        public bool ExisteEstudianteForaneo(int fci)
        {
            return contexto.Estudiantes.Any(es => es.fci == fci);
        }

        public IEnumerable<Estudiante> GetEstudiantes()
        {
            return contexto.Estudiantes.ToList();
        }

        public Perfil GetPerfil(int idperfil, int ci)
        {
            return contexto.Perfiles.Where(per => per.id == idperfil && per.estudianteCI == ci).FirstOrDefault();
        }

        public IEnumerable<Perfil> GetPerfilesDeEstudiante(int ci)
        {
            return contexto.Perfiles.Where(per => per.estudianteCI == ci).OrderBy(p=> p.estudiante.apellido);
        }

        public bool Guardar()
        {
            return (contexto.SaveChanges() >= 0);
        }
    }
}
