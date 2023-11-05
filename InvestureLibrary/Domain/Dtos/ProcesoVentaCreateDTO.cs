using System;

namespace JaveragesLibrary.Domain.Dtos
{
    public class ProcesoVentaCreateDTO
    {
        public required int Id { get; set; }
        public required DateTime FechaInicio { get; set; }        
        public required string Estado { get; set; } = string.Empty;
        public required int EmpleadoId { get; set; } 
    }
}