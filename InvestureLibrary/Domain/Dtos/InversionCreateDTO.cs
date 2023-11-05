using System;

namespace JaveragesLibrary.Domain.Dtos
{
    public class InversionCreateDTO
    {
        // No debería haber una propiedad Id aquí, ya que se generará automáticamente por la base de datos.
        public string Tipo { get; set; } = string.Empty;
        public double Monto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double RendimientoEsperado { get; set; }
        public double RendimientoActual { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
