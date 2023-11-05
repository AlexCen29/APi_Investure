using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestureLibrary.Domain.Dtos
{
    public class ClienteUpdateDTO
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int? Empleado_id { get; set; }
}

}