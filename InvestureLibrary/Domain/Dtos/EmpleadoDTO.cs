using System;

namespace JaveragesLibrary.Domain.Dtos
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellMater { get; set; } // Agrega esta propiedad para reflejar la columna 'apellMater'
        public string ApellPater { get; set; } // Agrega esta propiedad para reflejar la columna 'apellPater'
        public string Curp { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public int Rol_fk { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaContratacion { get; set; }
        public byte Estatus { get; set; }
    }
}
