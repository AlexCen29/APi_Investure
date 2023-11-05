using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using JaveragesLibrary.Domain.Entities;
using InvestureLibrary.Infrastructure.Data.Configurations;
using InvestureLibrary.Domain.Entities;


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


    public virtual DbSet<Inversion> Inversion { get; set; }
    public virtual DbSet<Inversion> Inversiones { get; set; }

    
    public virtual DbSet<Empresa> Empresas { get; set; }
    public virtual DbSet<Empresa> empresa { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }
    public virtual DbSet<Nota> nota { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<Empleado> empleado { get; set; }

    public virtual DbSet<Casa> Casas { get; set; }
    //public virtual DbSet<Clientes> Clientes { get; set; }
    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<ProcesoVenta> ProcesosDeVenta { get; set; }
    public virtual DbSet<Propiedad> Propiedades { get; set; }
    public virtual DbSet<Terreno> Terrenos { get; set; }
    public virtual DbSet<Villa> Villas { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }






    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

            modelBuilder.Entity<Empresa>()
        .ToTable("Empresas");

        modelBuilder.Entity<Empleado>()
        .ToTable("Empleados");
        modelBuilder.Entity<Cliente>()
                .ToTable("Clientes");

        modelBuilder.Entity<Propiedad>()
            .HasDiscriminator<string>("Tipo")
            .HasValue<Casa>("casas")
            .HasValue<Departamento>("departamentos")
            .HasValue<Terreno>("terrenos")
            .HasValue<Villa>("villas");

        modelBuilder.ApplyConfiguration(new InversionesConfiguration());
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PropiedadesConfiguration());


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
