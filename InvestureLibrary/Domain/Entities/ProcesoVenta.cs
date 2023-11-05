using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Entities
{
    public class ProcesoVenta
    {
        public required int Id { get; set; }
        public required DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public required string Estado { get; set; }  
        public required int EmpleadoId { get; set; }      
        public int PropiedadId { get; set; }      
    }
}