using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JaveragesLibrary.Domain.Entities;

namespace JaveragesLibrary.Infrastructure.Data.Configurations
{
    public class AsignarPermisoConfiguration : IEntityTypeConfiguration<AsignarPermiso>
    {
        public void Configure(EntityTypeBuilder<AsignarPermiso> builder)
        {
            builder.HasKey(e => e.Id); // Configura la clave principal
            builder.Property(e => e.Id_rol).IsRequired(); // Configura la propiedad Id_Rol como requerida
            builder.Property(e => e.Id_permiso).IsRequired(); // Configura la propiedad Id_Permiso como requerida

            // Configura las relaciones con las entidades relacionadas (Rol y Permiso)
            builder.HasOne(e => e.Rol)
                .WithMany()
                .HasForeignKey(e => e.Id_rol)
                .OnDelete(DeleteBehavior.Restrict); // Puedes ajustar la acción de eliminación según tus necesidades

            builder.HasOne(e => e.Permiso)
                .WithMany()
                .HasForeignKey(e => e.Id_permiso)
                .OnDelete(DeleteBehavior.Restrict); // Puedes ajustar la acción de eliminación según tus necesidades
        }
    }
}
