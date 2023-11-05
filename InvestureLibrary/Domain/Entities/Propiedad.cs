using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Entities
{
    // Propiedad representa la clase base de todas las propiedades
   public class Propiedad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public int EmpresaId { get; set; }
        public int MetrosCuadrados { get; set; }
        public int PrecioRenta { get; set; }
        public int PrecioVenta { get; set; }
        public int SubidoPor { get; set; }
        public string Tipo { get; set; }
    }

    // Casa hereda de Propiedad y agrega sus propios campos
    public class Casa : Propiedad
    {
        public int NumHabitaciones { get; set; }
        public int NumBanos { get; set; }
        public bool? Garage { get; set; }
        public int? TerrenoM2 { get; set; }
        public int Plantas { get; set; }
        public bool? CuartoDeServicio { get; set; }
        public bool? Piscina { get; set; }
    }


    // Departamento
    public class Departamento : Propiedad
    {
        public int? NumHabitaciones { get; set; }
        public int? NumBanos { get; set; }
        public byte Piso { get; set; }
        public bool? Cocina { get; set; }
        public bool? Elevador { get; set; }
        public bool? Balcon { get; set; }
        public bool? Estacionamiento { get; set; }
        public bool? Piscina { get; set; }
    }

    // Empleado



    // Lote
 // Nota
  


    // Terreno
    public class Terreno : Propiedad
    {
        public string TipoDeTerreno { get; set; }
        public string ServiciosPublicos { get; set; }
        public string UsoPrevisto { get; set; }
        public string Zonificacion { get; set; }
        public string Permisos { get; set; }
        public string Topografia { get; set; }
    }

    // Villa
    public class Villa : Propiedad
    {
        public int? NumHabitaciones { get; set; }
        public int? NumBanos { get; set; }
        public bool? Piscina { get; set; }
        public bool? Jardin { get; set; }
        public bool? Garage { get; set; }
        public string Comodidades { get; set; }
    }


}