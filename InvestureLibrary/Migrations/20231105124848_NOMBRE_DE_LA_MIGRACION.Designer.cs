﻿// <auto-generated />
using System;
using JaveragesLibrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Investure.Migrations
{
    [DbContext(typeof(JaveragesLibraryDbContext))]
    [Migration("20231105124848_NOMBRE_DE_LA_MIGRACION")]
    partial class NOMBRE_DE_LA_MIGRACION
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AsignarPermiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_permiso")
                        .HasColumnType("int");

                    b.Property<int>("Id_rol")
                        .HasColumnType("int");

                    b.Property<int?>("PermisoId")
                        .HasColumnType("int");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermisoId");

                    b.HasIndex("RolId");

                    b.ToTable("AsignarPermiso");
                });

            modelBuilder.Entity("InvestureLibrary.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Empleado_id")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellMater")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ApellPater")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Correo_electronico")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Curp")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Estatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rol_fk")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("Rol_fk");

                    b.ToTable("Empleados", (string)null);
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Inversion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<double>("RendimientoActual")
                        .HasColumnType("float");

                    b.Property<double>("RendimientoEsperado")
                        .HasColumnType("float");

                    b.Property<string>("Tipo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Inversio__3214EC073C97970F");

                    b.ToTable("Inversion");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int?>("Empleado_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Nota");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permiso");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.ProcesoVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropiedadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProcesosDeVenta");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Propiedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<int>("PrecioRenta")
                        .HasColumnType("int");

                    b.Property<int>("PrecioVenta")
                        .HasColumnType("int");

                    b.Property<int>("SubidoPor")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Propiedades");

                    b.HasDiscriminator<string>("Tipo").HasValue("Propiedad");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Casa", b =>
                {
                    b.HasBaseType("JaveragesLibrary.Domain.Entities.Propiedad");

                    b.Property<bool?>("CuartoDeServicio")
                        .HasColumnType("bit");

                    b.Property<bool?>("Garage")
                        .HasColumnType("bit");

                    b.Property<int>("NumBanos")
                        .HasColumnType("int");

                    b.Property<int>("NumHabitaciones")
                        .HasColumnType("int");

                    b.Property<bool?>("Piscina")
                        .HasColumnType("bit");

                    b.Property<int>("Plantas")
                        .HasColumnType("int");

                    b.Property<int?>("TerrenoM2")
                        .HasColumnType("int");

                    b.ToTable("Propiedades", t =>
                        {
                            t.Property("NumBanos")
                                .HasColumnName("Casa_NumBanos");

                            t.Property("NumHabitaciones")
                                .HasColumnName("Casa_NumHabitaciones");

                            t.Property("Piscina")
                                .HasColumnName("Casa_Piscina");
                        });

                    b.HasDiscriminator().HasValue("casas");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Departamento", b =>
                {
                    b.HasBaseType("JaveragesLibrary.Domain.Entities.Propiedad");

                    b.Property<bool?>("Balcon")
                        .HasColumnType("bit");

                    b.Property<bool?>("Cocina")
                        .HasColumnType("bit");

                    b.Property<bool?>("Elevador")
                        .HasColumnType("bit");

                    b.Property<bool?>("Estacionamiento")
                        .HasColumnType("bit");

                    b.Property<int?>("NumBanos")
                        .HasColumnType("int");

                    b.Property<int?>("NumHabitaciones")
                        .HasColumnType("int");

                    b.Property<bool?>("Piscina")
                        .HasColumnType("bit");

                    b.Property<byte>("Piso")
                        .HasColumnType("tinyint");

                    b.HasDiscriminator().HasValue("departamentos");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Terreno", b =>
                {
                    b.HasBaseType("JaveragesLibrary.Domain.Entities.Propiedad");

                    b.Property<string>("Permisos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiciosPublicos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDeTerreno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsoPrevisto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zonificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("terrenos");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Villa", b =>
                {
                    b.HasBaseType("JaveragesLibrary.Domain.Entities.Propiedad");

                    b.Property<string>("Comodidades")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Garage")
                        .HasColumnType("bit");

                    b.Property<bool?>("Jardin")
                        .HasColumnType("bit");

                    b.Property<int?>("NumBanos")
                        .HasColumnType("int");

                    b.Property<int?>("NumHabitaciones")
                        .HasColumnType("int");

                    b.Property<bool?>("Piscina")
                        .HasColumnType("bit");

                    b.ToTable("Propiedades", t =>
                        {
                            t.Property("Garage")
                                .HasColumnName("Villa_Garage");

                            t.Property("NumBanos")
                                .HasColumnName("Villa_NumBanos");

                            t.Property("NumHabitaciones")
                                .HasColumnName("Villa_NumHabitaciones");

                            t.Property("Piscina")
                                .HasColumnName("Villa_Piscina");
                        });

                    b.HasDiscriminator().HasValue("villas");
                });

            modelBuilder.Entity("AsignarPermiso", b =>
                {
                    b.HasOne("JaveragesLibrary.Domain.Entities.Permiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("PermisoId");

                    b.HasOne("JaveragesLibrary.Domain.Entities.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId");

                    b.Navigation("Permiso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Empleado", b =>
                {
                    b.HasOne("JaveragesLibrary.Domain.Entities.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("Rol_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("JaveragesLibrary.Domain.Entities.Nota", b =>
                {
                    b.HasOne("JaveragesLibrary.Domain.Entities.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId");

                    b.Navigation("Empleado");
                });
#pragma warning restore 612, 618
        }
    }
}
