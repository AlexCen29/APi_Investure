using JaveragesLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestureLibrary.Infrastructure.Data.Configurations
{
    public class PropiedadesConfiguration : IEntityTypeConfiguration<Propiedad>
    {
        public void Configure(EntityTypeBuilder<Propiedad> builder)
        {
            // Configuraciones específicas para la entidad Propiedades
            builder.HasKey(e => e.Id); // Ejemplo de configuración de clave primaria

            // Añade más configuraciones según tus necesidades

            // Si necesitas configurar relaciones, por ejemplo, puedes hacerlo aquí.
           //builder.HasMany(e => e.Clientes)
                   //.WithOne(c => c.Propiedad)
                //   .HasForeignKey(c => c.PropiedadId);
        }
    }
}
