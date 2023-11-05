using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace InvestureLibrary.Infrastructure.Data.Configurations
{
    public class NotaConfiguration : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(n => n.Id); 
            builder.Property(n => n.Contenido).IsRequired(); 
            builder.Property(n => n.Fecha); 
            builder.Property(n => n.Empleado_id);
            builder.Property(n => n.Tipo); 


            builder.HasOne(n => n.Empleado)
                .WithMany()
                .HasForeignKey(n => n.Empleado_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
//ya esta xd