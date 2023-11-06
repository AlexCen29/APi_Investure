using System;

namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class RegistroDeContactoQueryFilter
    {
        public int Id { get; set; }
        public int IdEmpleado_fk { get; set; }
        public int IdCliente_fk { get; set; } 
        public string TipoContacto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaContacto { get; set; }
        public string Estado { get; set; }
        public string Canal { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }
}
