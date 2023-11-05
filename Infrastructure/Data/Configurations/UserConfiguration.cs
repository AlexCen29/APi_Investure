// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using InvestureLibrary.Domain.Entities;
// using JaveragesLibrary.Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace InvestureLibrary.Infrastructure.Data.Configurations
// {
//     public class UserConfiguration: IEntityTypeConfiguration<USUARIO>
//     {
//         public void Configure(EntityTypeBuilder<USUARIO> builder)
//         {
//             builder.HasKey(e => e.UserId).HasName("PK__Inversio__3214EC073C97970F");

//             builder.Property(e => e.UserId).ValueGeneratedNever();
            
//             builder.Property(e => e.Nombre).HasMaxLength(100);
//             builder.Property(e => e.Email).HasMaxLength(100);

//         }
//     }
// }