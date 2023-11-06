using System;

namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class SeguimientoDeTareaQueryFilter
    {
        public int Id { get; set; }
        public int IdEmpleado_fk { get; set; }
        public string Tarea { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public byte Completada { get; set; }
    }
}
