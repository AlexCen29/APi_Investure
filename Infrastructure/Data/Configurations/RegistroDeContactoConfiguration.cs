using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class RegistroDeContactoConfiguration : IEntityTypeConfiguration<RegistroDeContacto>
    {
        public void Configure(EntityTypeBuilder<RegistroDeContacto> builder)
        {
            builder.HasKey(e => e.Id); 
            builder.Property(e => e.IdEmpleado_fk).IsRequired(); 
            builder.Property(e => e.IdCliente_fk).IsRequired(); 
            builder.Property(e => e.TipoContacto).HasMaxLength(1000); 
            builder.Property(e => e.Descripcion).HasMaxLength(1000); 
            builder.Property(e => e.FechaContacto).HasColumnType("datetime"); 
            builder.Property(e => e.Estado).HasMaxLength(1000); 
            builder.Property(e => e.Canal).HasMaxLength(100); 
            builder.Property(e => e.FechaHoraInicio).HasColumnType("datetime"); 
            builder.Property(e => e.FechaHoraFin).HasColumnType("datetime"); 

            
            builder.HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.IdEmpleado_fk)
                .OnDelete(DeleteBehavior.Restrict);
                
            
            builder.HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.IdCliente_fk)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
