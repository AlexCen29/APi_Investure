using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class EmpresaQueryFilter
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
        public string? RFC { get; set; }
        // Otras propiedades de filtro si es necesario
    }
}
