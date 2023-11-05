using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaveragesLibrary.Domain.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string RFC { get; set; }
    }
}
