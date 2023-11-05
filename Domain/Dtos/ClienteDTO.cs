using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestureLibrary.Domain.Dtos
{
    public class ClienteDTO
    {


    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int? EmpleadoId { get; set; }

    }
}