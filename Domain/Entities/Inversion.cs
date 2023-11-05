using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace JaveragesLibrary.Domain.Entities
{
    public class Inversion
    
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esta anotación indica que el valor es autoincremental
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public double Monto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double RendimientoEsperado { get; set; }
        public double RendimientoActual { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
