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

    public virtual DbSet<RegistroDeContacto> RegistroDeContacto { get; set; }

   public virtual DbSet<SeguimientoDeTarea> SeguimientoDeTareas { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegistroDeContacto>()
                .HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.IdEmpleado_fk)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegistroDeContacto>()
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.IdCliente_fk)
                .OnDelete(DeleteBehavior.Restrict);
            
            OnModelCreatingPartial(modelBuilder);
        }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
