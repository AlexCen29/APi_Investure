using System;

namespace JaveragesLibrary.Domain.Dtos
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Telefono { get; set; }
        
    }
}