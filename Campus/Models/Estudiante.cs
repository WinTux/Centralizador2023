using System.ComponentModel.DataAnnotations;

namespace Campus.Models
{
    public class Estudiante
    {
        [Key]
        [Required]
        public int ci { get; set; }
        [Required]
        public int fci { get; set; }// de foreign ci
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public DateTime fecha_nac { get; set; }
        public string? email { get; set; }
        public string? direccion { get; set; }
        public ICollection<Perfil> perfiles { get; set; } = new List<Perfil>();
    }
}
