using System.ComponentModel.DataAnnotations;

namespace Centralizador2023.Models
{
    public class Programador
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cargo { get; set; }
    }
}
