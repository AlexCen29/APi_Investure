using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class ClienteUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string CorreoElectronico { get; set; }

        [Required]
        public DateTime FechaNac { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public int Telefono { get; set; }

        [Required]
        public int IdEmpleado_fk { get; set; } 

    }
}
