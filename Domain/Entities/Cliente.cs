using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Empleado")]
        public int IdEmpleado_fk { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Telefono { get; set; }

        public Empleado Empleado { get; set; }
    }
}
