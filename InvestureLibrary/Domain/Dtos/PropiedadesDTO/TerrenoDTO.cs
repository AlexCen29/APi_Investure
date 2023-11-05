using System;
using JaveragesLibrary.Domain.Entities;
namespace JaveragesLibrary.Domain.Dtos
{
public class TerrenoDTO : PropiedadDTO
{
    public string TipoDeTerreno { get; set; }
    public string ServiciosPublicos { get; set; }
    public string UsoPrevisto { get; set; }
    public string Zonificacion { get; set; }
    public string Permisos { get; set; }
    public string Topografia { get; set; }
}

}
