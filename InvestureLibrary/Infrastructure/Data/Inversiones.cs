using System;
using System.Collections.Generic;

namespace JaveragesLibrary.Domain.Entities;

public partial class Inversiones
{
    public int Id { get; set; }

    public string Tipo { get; set; }

    public double? Monto { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public double? RendimientoEsperado { get; set; }

    public double? RendimientoActual { get; set; }

    public string Estado { get; set; }
}
