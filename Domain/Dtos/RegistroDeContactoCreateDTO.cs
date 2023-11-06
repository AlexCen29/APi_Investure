using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class RegistroDeContactoCreateDTO
    {
        [Required]
        public int IdEmpleado_fk { get; set; }

        [Required]
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
    }
}
