using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JaveragesLibrary.Domain.Entities;

using System.ComponentModel.DataAnnotations;

public class AsignarPermiso
{
    public int Id { get; set; }

    [Required] 
    [ForeignKey("Rol")]
    public int Id_rol { get; set; }

    [Required] 
    [ForeignKey("Permiso")]
    public int Id_permiso { get; set; }

    public Rol Rol { get; set; }
    public Permiso Permiso { get; set; }
}

