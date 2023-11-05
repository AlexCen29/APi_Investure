using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class EventoCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Tipo { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(100)]
        public string FechaDeCreacion { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }

        [Required]
        public int IdEmpleado_FK { get; set; } // Representa la clave foránea
    }
}
