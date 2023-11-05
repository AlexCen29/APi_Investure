public class NotaUpdateDTO
{
    public required int Id { get; set; }
    public required string Contenido { get; set; }
    public DateTime Fecha { get; set; }
    public int Empleado_id { get; set; }
    public string Tipo { get; set; }
}