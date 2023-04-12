using Centralizador2023.Models;

namespace Centralizador2023.Repositorios
{
    public interface IProgramadorRepository
    {
        IEnumerable<Programador> GetProgramadores();
        Programador GetProgramadorById(int id);
    }
}
