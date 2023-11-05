namespace JaveragesLibrary.Domain.Dtos.QueryFilters
{
    public class PropiedadQueryFilter
    {
        public int Id { get; set; } 
        
        public string? Direccion { get; set; }

        public string? Tipo { get; set; }

        public int MinMetrosCuadrados { get; set; }

        public int MaxMetrosCuadrados { get; set; }

        public int MinPrecioVenta { get; set; }

        public int MaxPrecioVenta { get; set; }

        public int MinPrecioRenta { get; set; }

        public int MaxPrecioRenta { get; set; }

        public int EmpresaId { get; set; }
    }
}
