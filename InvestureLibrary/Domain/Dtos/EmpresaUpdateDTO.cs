using System;

namespace JaveragesLibrary.Domain.Dtos
{
    public class EmpresaUpdateDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string RFC { get; set; }
        // Otras propiedades de actualización si es necesario
    }
}
