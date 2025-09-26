

using Application.Dtos.MacroindicatorDto;
using Application.Services.Interface;
using Application.Validations.Inteface;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Repositpries.Interface;

namespace Application.Services
{
    public class MacroindicatorService : IMacroindicatorService
    {
        private readonly IMacroindicatorRepository _macroindicatorRepository;
        private readonly IWeightValidation _weightValidation;

        public MacroindicatorService(IMacroindicatorRepository macroindicatorRepository, IWeightValidation weightValidation)
        {
            _macroindicatorRepository = macroindicatorRepository;
            _weightValidation = weightValidation;
        }

        // Crear
        public async Task<bool> CreateAsync(CreateMacroindicatorDto dto)
        {
            try
            {
                if (await _weightValidation.IsSumExceededAsync(dto.Weight))
                    return false;

                var entity = new Macroindicator
                {
                    Id = 0,
                    Name = dto.Name,
                    Weight = dto.Weight,
                    HigherIsBetter = dto.HigherIsBetter
                };

                var created = await _macroindicatorRepository.AddAsync(entity);
                return created != null;
            }
            catch
            {
                return false;
            }
        }

        // Leer todos
        public async Task<List<ReedMacroindicatorDto>> GetAllAsync()
        {
            try
            {
                var entitiesList = await _macroindicatorRepository.GetAllList();
                return entitiesList.Select(c => new ReedMacroindicatorDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Weight = c.Weight,
                    HigherIsBetter = c.HigherIsBetter
                }).ToList();
            }
            catch
            {
                return [];
            }
        }

        // Leer con include
        public async Task<List<ReedMacroindicatorDto>> GetAllWithIncludeAsync()
        {
            try
            {
                var entitiesList = await _macroindicatorRepository
                    .GetAllQuery()
                    .Include(c => c.Indicators)
                    .ToListAsync();

                return entitiesList.Select(c => new ReedMacroindicatorDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Weight = c.Weight,
                    HigherIsBetter = c.HigherIsBetter
                }).ToList();
            }
            catch
            {
                return [];
            }
        }

        // Leer por ID
        public async Task<ReedMacroindicatorDto?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _macroindicatorRepository.GetById(id);
                if (entity == null) return null;

                return new ReedMacroindicatorDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Weight = entity.Weight,
                    HigherIsBetter = entity.HigherIsBetter
                };
            }
            catch
            {
                return null;
            }
        }

        // Actualizar
        public async Task<bool> UpdateAsync(UpdateMacroindicatorDto dto)
        {
            try
            {
                if (await _weightValidation.IsSumExceededAsync(dto.Weight))
                    return false;

                var entity = new Macroindicator
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Weight = dto.Weight,
                    HigherIsBetter = dto.HigherIsBetter
                };

                var updated = await _macroindicatorRepository.UpdateAsync(entity.Id, entity);
                return updated != null;
            }
            catch
            {
                return false;
            }
        }

        // Eliminar
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _macroindicatorRepository.DeleteAsync(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
