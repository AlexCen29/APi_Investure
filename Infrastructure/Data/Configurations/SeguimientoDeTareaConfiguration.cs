using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class SeguimientoDeTareaConfiguration : IEntityTypeConfiguration<SeguimientoDeTarea>
    {
        public void Configure(EntityTypeBuilder<SeguimientoDeTarea> builder)
        {
            builder.HasKey(e => e.Id); 
            builder.Property(e => e.IdEmpleado_fk).IsRequired(); 
            builder.Property(e => e.Tarea).HasMaxLength(1000); 
            builder.Property(e => e.FechaInicio).HasColumnType("datetime"); 
            builder.Property(e => e.FechaFin).HasColumnType("datetime"); 
            builder.Property(e => e.Completada).IsRequired(); 

            builder.HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.IdEmpleado_fk)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
