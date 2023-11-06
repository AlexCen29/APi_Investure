using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Entities;



namespace JaveragesLibrary.Infrastructure.Data;

public partial class JaveragesLibraryDbContext : DbContext
{
    public JaveragesLibraryDbContext()
    {
    }

    public JaveragesLibraryDbContext(DbContextOptions<JaveragesLibraryDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Permiso> Permisos { get; set; }
    public virtual DbSet<Permiso> permiso { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }
    public virtual DbSet<Rol> rol { get; set; }

    public virtual DbSet<AsignarPermiso> AsignarPermisos { get; set; }
    public virtual DbSet<AsignarPermiso> asignarPermiso { get; set; }




    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<Empleado> empleado { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }
    public virtual DbSet<Evento> evento { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Cliente> cliente { get; set; }








    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
