using JaveragesLibrary.Domain.Entities;
namespace JaveragesLibrary.Domain.Dtos
{
    public class DepartamentoDTO : PropiedadDTO
{
    public int NumHabitaciones { get; set; }
    public int NumBanos { get; set; }
    public int Piso { get; set; }
    public bool Cocina { get; set; }
    public bool Elevador { get; set; }
    public bool Balcon { get; set; }
    public bool Estacionamiento { get; set; }
    public bool Piscina { get; set; }
}

}