using System;
using JaveragesLibrary.Domain.Entities;
namespace JaveragesLibrary.Domain.Dtos
{
     public class CasaDTO : PropiedadDTO
    {
        public int NumHabitaciones { get; set; }
        public int NumBanos { get; set; }
        public bool? Garage { get; set; }
        public int? TerrenoM2 { get; set; }
        public int Plantas { get; set; }
        public bool? CuartoDeServicio { get; set; }
        public bool? Piscina { get; set; }
    }

}
