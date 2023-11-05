using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Dtos
{
    public class AsignarPermisoUpdateDTO
    {
        public int Id { get; set; }
        public int Id_Rol { get; set; }
        public int Id_Permiso { get; set; }

    }
}