using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Entities
{
    public class RegistroDeContacto
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Empleado")]
        public int IdEmpleado_fk { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente_fk { get; set; }

        [Required]
        [StringLength(1000)]
        public string TipoContacto { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaContacto { get; set; }

        [Required]
        [StringLength(1000)]
        public string Estado { get; set; }

        [Required]
        [StringLength(100)]
        public string Canal { get; set; }

        [Required]
        public DateTime FechaHoraInicio { get; set; }

        [Required]
        public DateTime FechaHoraFin { get; set; }

        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
    }
}
