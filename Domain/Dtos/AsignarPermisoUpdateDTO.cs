using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Dtos
{
    public class AsignarPermisoUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public int Id_Rol { get; set; }
        [Required]
        public int Id_Permiso { get; set; }

    }
}