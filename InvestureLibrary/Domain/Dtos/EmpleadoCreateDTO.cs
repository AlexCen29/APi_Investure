using System;

using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class EmpleadoCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string ApellMater { get; set; }

        [StringLength(100)]
        public string ApellPater { get; set; }

        [StringLength(20)]
        public string Curp { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }


        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        public int Rol_fk { get; set; }

        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        [Required]
        public DateTime FechaNac { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }

        [Required]
        public byte Estatus { get; set; }
    }
}
