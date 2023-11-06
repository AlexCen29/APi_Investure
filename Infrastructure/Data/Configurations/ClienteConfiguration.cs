using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id); // Configura la clave principal
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(100); // Configura la propiedad Nombre
            builder.Property(e => e.CorreoElectronico).HasMaxLength(100); // Configura la propiedad CorreoElectronico
            builder.Property(e => e.FechaNac).HasColumnType("datetime"); // Configura la propiedad FechaNac
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime"); // Configura la propiedad FechaCreacion
            builder.Property(e => e.Telefono).IsRequired(); // Configura la propiedad Telefono
            builder.Property(e => e.IdEmpleado_fk).IsRequired(); // Configura la propiedad IdEmpleado_fk

            // Configura la relación con la entidad Empleado
            builder.HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.IdEmpleado_fk)
                .OnDelete(DeleteBehavior.Restrict); // Esto configura una relación, ajusta según tus necesidades
        }
    }
}
