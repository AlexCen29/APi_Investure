using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.Id); // Configura la clave principal
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(100); // Configura la propiedad Nombre
            builder.Property(e => e.ApellMater).HasMaxLength(100); // Configura la propiedad ApellMater
            builder.Property(e => e.ApellPater).HasMaxLength(100); // Configura la propiedad ApellPater
            builder.Property(e => e.Curp).HasMaxLength(20); // Configura la propiedad Curp
            builder.Property(e => e.Sexo).HasMaxLength(1); // Configura la propiedad Sexo
            builder.Property(e => e.Direccion).HasMaxLength(100); // Configura la propiedad Direccion
            builder.Property(e => e.Rol_fk).IsRequired(); // Configura la propiedad Rol_fk
            builder.Property(e => e.Correo_electronico).HasMaxLength(100); // Configura la propiedad Correo_electronico
            builder.Property(e => e.FechaNac).HasColumnType("datetime"); // Configura la propiedad FechaNac
            builder.Property(e => e.FechaContratacion).HasColumnType("datetime"); // Configura la propiedad FechaContratacion
            builder.Property(e => e.Estatus).IsRequired(); // Configura la propiedad Estatus

            // Configura la relación con la entidad Rol
            builder.HasOne(e => e.Rol)
                .WithMany()
                .HasForeignKey(e => e.Rol_fk)
                .OnDelete(DeleteBehavior.Restrict); // Esto configura una relación, ajusta según tus necesidades
        }
    }
}
