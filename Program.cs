using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;
using JaveragesLibrary.Services.Features.Inversiones;
using JaveragesLibrary.Services.Features.Empresas;
using JaveragesLibrary.Services.Features.Empleados;
using JaveragesLibrary.Services.Mappings;
using JaveragesLibrary.Services.Features.Propiedades;
using JaveragesLibrary.Services.Features.Notas;
using InvestureLibrary.Domain.Dtos;
using InvestureLibrary.Infrastructure.Repositories;
using JaveragesLibrary.Services.Features.Permisos;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Services.Features.Roles;
using JaveragesLibrary.Services.Features.AsignarPermisos;
using JaveragesLibrary.Services.Features.Eventos;
using JaveragesLibrary.Services.Features.Clientes;

// using JaveragesLibrary.Services.Features.Notas;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Configurar DbContext
builder.Services.AddDbContext<JaveragesLibraryDbContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
});

// Configurar Repositorios
builder.Services.AddScoped<PermisoRepository>();
builder.Services.AddScoped<RolRepository>();
builder.Services.AddScoped<AsignarPermisoRepository>();
builder.Services.AddScoped<EmpleadoRepository>();
builder.Services.AddScoped<EventoRepository>();
builder.Services.AddScoped<ClienteRepository>();



builder.Services.AddScoped<InversionRepository>();
builder.Services.AddScoped<EmpresaRepository>();
builder.Services.AddScoped<IPropiedadRepository, PropiedadRepository>();//agregar esta línea
builder.Services.AddScoped<NotaRepository>();


// y Servicios
builder.Services.AddScoped<PermisoService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<AsignarPermisoService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<ClienteService>();


builder.Services.AddScoped<InversionService>();
builder.Services.AddScoped<EmpresaService>();
builder.Services.AddScoped<NotaService>();



// Registrar IPropiedadService y PropiedadService
builder.Services.AddScoped<IPropiedadService, PropiedadService>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(ResponseMappingProfile), typeof(RequestCreateMappingProfile));
builder.Services.AddAutoMapper(typeof(IServiceCollection));
// Configurar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Middleware


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();