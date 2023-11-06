using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Dtos
{
    public class ClienteCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        [Required]
        public DateTime FechaNac { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public int Telefono { get; set; }
        
        [ForeignKey("Empleado")]
        public int IdEmpleado_fk { get; set; }

    }
}
