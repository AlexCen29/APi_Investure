namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class InversionQueryFilter
    {
        public int Id { get; set; } 
        
        public string? Nombre { get; set; }

        public string? Tipo { get; set; }
        public DateTime StartFechaInicio { get; set; }

        public DateTime EndFechaInicio { get; set; }

        public DateTime StartFechaFin { get; set; }

        public DateTime EndFechaFin { get; set; }

        public double MinRendimientoEsperado { get; set; }

        public double MaxRendimientoEsperado { get; set; }

        public double MinRendimientoActual { get; set; }

        public double MaxRendimientoActual { get; set; }

        public string ? Estado { get; set; }
    }
}
