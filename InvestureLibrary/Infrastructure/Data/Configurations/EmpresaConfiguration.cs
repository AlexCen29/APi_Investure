using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace InvestureLibrary.Infrastructure.Data.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id); // Configura la clave principal
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(255); // Configura la propiedad Nombre
            builder.Property(e => e.Ubicacion).HasMaxLength(255); // Configura la propiedad Ubicacion
            builder.Property(e => e.RFC).HasMaxLength(20); // Configura la propiedad RFC
        }
    }
}
