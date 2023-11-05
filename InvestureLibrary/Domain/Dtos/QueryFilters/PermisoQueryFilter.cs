
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class PermisoQueryFilter
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
