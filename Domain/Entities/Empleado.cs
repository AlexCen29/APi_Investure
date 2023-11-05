using System;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Entities
{

    public class Empleado
    {
        public int Id { get; set; }

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
        [ForeignKey("Rol")]
        public int Rol_fk { get; set; }

        [StringLength(100)]
        public string Correo_electronico { get; set; }

        public DateTime FechaNac { get; set; }

        public DateTime FechaContratacion { get; set; }

        public byte Estatus { get; set; }

        public Rol Rol { get; set; }
    }
}