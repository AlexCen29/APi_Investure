using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Entities
{
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Rol")]
        public int IdEmpleado_fk { get; set; }

        [Required]
        [StringLength(100)]
        public string Tipo { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(100)]
        public string FechaDeCreacion { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }
        public Empleado Empleado { get; set; }
    }
}
