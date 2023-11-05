// InversionRepository.cs
namespace JaveragesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

    public partial class InversionRepository
    {
       

        public async Task<int> GetTotalInversiones()
        {
            var totalInversiones = await _context.Inversion.CountAsync();
            return totalInversiones;
        }
    }

