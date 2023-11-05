using System;

namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class EventoQueryFilter
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string FechaDeCreacion { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdEmpleado_FK { get; set; } // Representa la relación con Empleado
    }
}
