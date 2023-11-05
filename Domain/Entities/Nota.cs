using System;

namespace JaveragesLibrary.Domain.Entities
{
    public class Nota
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Empleado_id { get; set; }
        public string Tipo { get; set; }
        public Empleado Empleado { get; set; } 
    }
}
