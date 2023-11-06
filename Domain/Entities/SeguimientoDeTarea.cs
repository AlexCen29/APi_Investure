using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Entities
{
    public class SeguimientoDeTarea
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Empleado")]
        public int IdEmpleado_fk { get; set; }

        [Required]
        [StringLength(1000)]
        public string Tarea { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public byte Completada { get; set; }

        public Empleado Empleado { get; set; }
    }
}
