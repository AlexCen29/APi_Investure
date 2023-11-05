using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(e => e.Id); // Configura la clave principal
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(255); // Configura la propiedad Nombre
            builder.Property(e => e.Descripcion).HasMaxLength(500); // Configura la propiedad Descripcion
        }
    }
}
