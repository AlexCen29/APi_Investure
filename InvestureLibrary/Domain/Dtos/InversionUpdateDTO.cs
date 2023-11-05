public class InversionUpdateDTO
{
    public int Id { get; set; } // Agregar el campo Id
    public string Tipo { get; set; }
    public double Monto { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public double RendimientoEsperado { get; set; }
    public double RendimientoActual { get; set; }
    // Otras propiedades de actualización
}
