using System;
using System.ComponentModel.DataAnnotations;

namespace JaveragesLibrary.Domain.Dtos
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public int IdEmpleado_fk { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string FechaDeCreacion { get; set; }
        public DateTime FechaCita { get; set; }
    }
}
