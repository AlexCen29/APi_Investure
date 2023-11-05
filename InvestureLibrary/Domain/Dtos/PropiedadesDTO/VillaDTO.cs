using System;
using JaveragesLibrary.Domain.Entities;
namespace JaveragesLibrary.Domain.Dtos
{
    public class VillaDTO : PropiedadDTO
{
    public int NumHabitaciones { get; set; }
    public int NumBanos { get; set; }
    public bool Piscina { get; set; }
    public bool Jardin { get; set; }
    public bool Garage { get; set; }
    public string Comodidades { get; set; }
}

}
