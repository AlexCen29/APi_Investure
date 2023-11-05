using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class NotaQueryFilter
    {
        public required int Id { get; set; }
        public required string? Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public string? Empleado_id { get; set; }
        public string? Tipo { get; set; }
    }
}
