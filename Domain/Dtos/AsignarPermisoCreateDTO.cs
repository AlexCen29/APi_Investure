using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Dtos
{
    public class AsignarPermisoCreateDTO
    {
        [ForeignKey("Rol")]
        public int Id_Rol { get; set; }
        [ForeignKey("Permiso")]
        public int Id_Permiso { get; set; }

    }
}