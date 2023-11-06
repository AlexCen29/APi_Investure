using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class AsignarPermisoConfiguration : IEntityTypeConfiguration<AsignarPermiso>
    {
        public void Configure(EntityTypeBuilder<AsignarPermiso> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id_rol).IsRequired(); 
            builder.Property(e => e.Id_permiso).IsRequired(); 

            
            builder.HasOne(e => e.Rol)
                .WithMany()
                .HasForeignKey(e => e.Id_rol)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Permiso)
                .WithMany()
                .HasForeignKey(e => e.Id_permiso)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
