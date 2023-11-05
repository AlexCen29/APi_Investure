using System;

using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class EmpleadoUpdateDTO
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)] // Agrega la restricción de longitud máxima
        public string Nombre { get; set; }

        [StringLength(100)] // Agrega la restricción de longitud máxima
        public string ApellMater { get; set; }

        [StringLength(100)] // Agrega la restricción de longitud máxima
        public string ApellPater { get; set; }

        [StringLength(20)] // Agrega la restricción de longitud máxima
        public string Curp { get; set; }

        [Required]
        [StringLength(1)] // Agrega la restricción de longitud máxima
        public string Sexo { get; set; }

        [StringLength(100)] // Agrega la restricción de longitud máxima
        public string Direccion { get; set; }

        [Required]
        public int Rol_fk { get; set; } // Debes asegurarte de que esta propiedad sea requerida

        [StringLength(100)] // Agrega la restricción de longitud máxima
        public string Correo_Electronico { get; set; }

        [Required]
        public DateTime FechaNac { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }

        [Required]
        public byte Estatus { get; set; }
    }
}
