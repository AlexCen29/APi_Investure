using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Entities
{
    public class PropiedadDTO
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
}