using System.ComponentModel.DataAnnotations;

namespace Campus.Models
{
    public class Perfil
    {
        [Key]
        [Required]
        public int id { get; set;}
        [Required]
        public string nick { get; set; }
        [Required]
        public string descripcion { get; set; }
        public string lenguajes { get; set; }
        [Required]
        public int estudianteCI { get; set; }//para relacionarse con fci
        public Estudiante estudiante { get; set; }//para navegar entre entidades
    }
}
