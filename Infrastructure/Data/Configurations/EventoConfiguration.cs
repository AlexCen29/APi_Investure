using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento> // Cambia la entidad a Evento
    {
        public void Configure(EntityTypeBuilder<Evento> builder) // Cambia el tipo de builder a Evento
        {
            builder.HasKey(e => e.Id); // Configura la clave principal
            builder.Property(e => e.Tipo).HasMaxLength(100); // Configura la propiedad Tipo
            builder.Property(e => e.Descripcion).HasMaxLength(500); // Configura la propiedad Descripcion
            builder.Property(e => e.FechaDeCreacion).HasMaxLength(100); // Configura la propiedad FechadeCreacion
            builder.Property(e => e.FechaCita).HasColumnType("datetime"); // Configura la propiedad FechaCita

            // Configura la relación con la entidad Empleado (idempleado_fk)
            builder.HasOne(e => e.Empleado) // Ajusta según tus necesidades
                .WithMany() // Ajusta según tus necesidades
                .HasForeignKey(e => e.IdEmpleado_fk) // Ajusta según tus necesidades
                .OnDelete(DeleteBehavior.Restrict); // Esto configura una relación, ajusta según tus necesidades
        }
    }
}
