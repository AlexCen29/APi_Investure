using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JaveragesLibrary.Domain.Dtos;
using JaveragesLibrary.Domain.Dtos.QueryFilters;
using JaveragesLibrary.Domain.Entities;
using JaveragesLibrary.Infrastructure.Data;
using JaveragesLibrary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JaveragesLibrary.Services.Features.Notas
{
    public class NotaService
    {
        private readonly NotaRepository _notaRepository;
        private readonly IMapper _mapper;
        private readonly JaveragesLibraryDbContext _dbContext;

        public NotaService(JaveragesLibraryDbContext dbContext, NotaRepository notaRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _notaRepository = notaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Nota>> GetAll(NotaQueryFilter notaQueryFilter)
        {
            return await _notaRepository.GetAll(notaQueryFilter);
        }

        public async Task<NotaDTO> GetById(int id)
        {
            var nota = await _notaRepository.GetById(id);
            return _mapper.Map<NotaDTO>(nota);
        }

        public async Task Add(NotaCreateDTO nota)
        {
            var entity = _mapper.Map<Nota>(nota);
            _dbContext.Notas.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(NotaUpdateDTO notaUpdate)
        {
            var existingNota = await _notaRepository.GetById(notaUpdate.Id);

            if (existingNota == null)
            {
                throw new InvalidOperationException("La nota no se encontró.");
            }

            existingNota.Contenido = notaUpdate.Contenido;
            existingNota.Fecha = notaUpdate.Fecha;
            existingNota.Empleado_id = notaUpdate.Empleado_id;
            existingNota.Tipo = notaUpdate.Tipo;

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _notaRepository.Delete(id);
        }
    }
}
