using System;

namespace JaveragesLibrary.Domain.Dtos
{
    public class NotaCreateDTO
    {
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int Empleado_id { get; set; }
        public string Tipo { get; set; }
    }
}