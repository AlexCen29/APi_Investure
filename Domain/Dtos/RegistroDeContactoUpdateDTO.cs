using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class RegistroDeContactoUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)] // Agrega la restricción de longitud máxima
        public string TipoContacto { get; set; }

        [Required]
        [StringLength(1000)] // Agrega la restricción de longitud máxima
        public string Descripcion { get ; set; }

        [Required]
        public DateTime FechaContacto { get; set; }

        [Required]
        [StringLength(1000)] // Agrega la restricción de longitud máxima
        public string Estado { get; set; }

        [Required]
        [StringLength(100)] // Agrega la restricción de longitud máxima
        public string Canal { get; set; }

        [Required]
        public DateTime FechaHoraInicio { get; set; }

        [Required]
        public DateTime FechaHoraFin { get; set; }
        
        [Required]
        public int IdEmpleado_fk { get; set; }
        [Required]
        public int IdCliente_fk { get; set; }
    }
}
