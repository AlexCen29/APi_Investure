using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class SeguimientoDeTareaUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Tarea { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public byte Completada { get; set; }

        [Required]
        public int IdEmpleado_fk { get; set; }
    }
}
