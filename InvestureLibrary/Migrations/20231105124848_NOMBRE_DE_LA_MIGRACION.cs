using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Investure.Migrations
{
    /// <inheritdoc />
    public partial class NOMBRE_DE_LA_MIGRACION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empleado_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    RendimientoEsperado = table.Column<double>(type: "float", nullable: false),
                    RendimientoActual = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inversio__3214EC073C97970F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcesosDeVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesosDeVenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    MetrosCuadrados = table.Column<int>(type: "int", nullable: false),
                    PrecioRenta = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<int>(type: "int", nullable: false),
                    SubidoPor = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Casa_NumHabitaciones = table.Column<int>(type: "int", nullable: true),
                    Casa_NumBanos = table.Column<int>(type: "int", nullable: true),
                    Garage = table.Column<bool>(type: "bit", nullable: true),
                    TerrenoM2 = table.Column<int>(type: "int", nullable: true),
                    Plantas = table.Column<int>(type: "int", nullable: true),
                    CuartoDeServicio = table.Column<bool>(type: "bit", nullable: true),
                    Casa_Piscina = table.Column<bool>(type: "bit", nullable: true),
                    NumHabitaciones = table.Column<int>(type: "int", nullable: true),
                    NumBanos = table.Column<int>(type: "int", nullable: true),
                    Piso = table.Column<byte>(type: "tinyint", nullable: true),
                    Cocina = table.Column<bool>(type: "bit", nullable: true),
                    Elevador = table.Column<bool>(type: "bit", nullable: true),
                    Balcon = table.Column<bool>(type: "bit", nullable: true),
                    Estacionamiento = table.Column<bool>(type: "bit", nullable: true),
                    Piscina = table.Column<bool>(type: "bit", nullable: true),
                    TipoDeTerreno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiciosPublicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsoPrevisto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zonificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permisos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Villa_NumHabitaciones = table.Column<int>(type: "int", nullable: true),
                    Villa_NumBanos = table.Column<int>(type: "int", nullable: true),
                    Villa_Piscina = table.Column<bool>(type: "bit", nullable: true),
                    Jardin = table.Column<bool>(type: "bit", nullable: true),
                    Villa_Garage = table.Column<bool>(type: "bit", nullable: true),
                    Comodidades = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AsignarPermiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_rol = table.Column<int>(type: "int", nullable: false),
                    Id_permiso = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    PermisoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignarPermiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsignarPermiso_Permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permiso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AsignarPermiso_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellMater = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApellPater = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Curp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Rol_fk = table.Column<int>(type: "int", nullable: false),
                    Correo_electronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Rol_Rol_fk",
                        column: x => x.Rol_fk,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Empleado_id = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nota_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignarPermiso_PermisoId",
                table: "AsignarPermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignarPermiso_RolId",
                table: "AsignarPermiso",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Rol_fk",
                table: "Empleados",
                column: "Rol_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_EmpleadoId",
                table: "Nota",
                column: "EmpleadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignarPermiso");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Inversion");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "ProcesosDeVenta");

            migrationBuilder.DropTable(
                name: "Propiedades");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
