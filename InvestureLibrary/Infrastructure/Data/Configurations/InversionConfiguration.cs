using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestureLibrary.Infrastructure.Data.Configurations
{
    public class InversionesConfiguration : IEntityTypeConfiguration<Inversion>
    {
        public void Configure(EntityTypeBuilder<Inversion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Inversio__3214EC073C97970F");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Estado).HasMaxLength(50);
            builder.Property(e => e.FechaFin).HasColumnType("datetime");
            builder.Property(e => e.FechaInicio).HasColumnType("datetime");
            builder.Property(e => e.Tipo).HasMaxLength(100);
        }
    }
}
