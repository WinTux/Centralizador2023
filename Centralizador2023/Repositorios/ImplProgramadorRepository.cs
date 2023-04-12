using Centralizador2023.Models;

namespace Centralizador2023.Repositorios
{
    public class ImplProgramadorRepository : IProgramadorRepository
    {
        public Programador GetProgramadorById(int id)
        {
            return new Programador
            {
                id = 1,
                nombre = "Sofía",
                apellido = "Rocha",
                cargo = "Desarrollador Core"
            };
        }

        public IEnumerable<Programador> GetProgramadores()
        {
            var progs = new List<Programador> { 
                new Programador{ 
                    id = 1,
                    nombre = "Pepe",
                    apellido = "Perales",
                    cargo = "Soporte"
                },
                new Programador{
                    id = 2,
                    nombre = "Ana",
                    apellido = "Sosa",
                    cargo = "Auxiliar de sistemas"
                }
            };
            return progs;
        }
    }
}
