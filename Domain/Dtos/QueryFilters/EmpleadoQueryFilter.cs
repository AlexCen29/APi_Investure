using System;

namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class EmpleadoQueryFilter
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellMater { get; set; }
        public string ApellPater { get; set; }
        public string CURP { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public int Rol_fk { get; set; }
        public string Correo_electronico { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaContratacion { get; set; }
        public byte Estatus { get; set; }
    }
}

