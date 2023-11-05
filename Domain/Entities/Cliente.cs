using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestureLibrary.Domain.Entities
{
    public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int? Empleado_id { get; set; }

    // Relación con el empleado si es necesario

}
}