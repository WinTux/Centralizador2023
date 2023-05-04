﻿using System.ComponentModel.DataAnnotations;

namespace Centralizador2023.DTO
{
    public class EstudiantePublisherDTO
    {
        public int ci { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nac { get; set; }
        public string tipoEvento { get; set; }
        
    }
}
