using Campus.Models;

namespace Campus.Conexion
{
    public interface IPerfilRepository
    {
        //Para estudaintes
        IEnumerable<Estudiante> GetEstudiantes();
        void CrearEstudiante(Estudiante est);
        bool ExisteEstudiante(int ci);
        //Para perfiles
        Perfil GetPerfil(int idperfil, int ci);
        IEnumerable<Perfil> GetPerfilesDeEstudiante(int ci);
        void CrearPerfil(int ci, Perfil per);

        bool ExisteEstudianteForaneo(int fci);

        bool Guardar();
    }
}
