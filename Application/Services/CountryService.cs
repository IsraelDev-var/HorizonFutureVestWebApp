using Application.Dtos.CountryDto;
using Application.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Repositpries.Interface;


namespace Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // Crear
        public async Task<bool> CreateAsync(CreateCountryDto dto)
        {
            try
            {
                var entity = new Country { Id = 0, Name = dto.Name, ISOCode = dto.ISOCode };
                var returnEntity = await _countryRepository.AddAsync(entity);
                return returnEntity != null;
            }
            catch
            {
                return false;
            }
        }

        // Leer todos
        public async Task<List<ReedCountryDto>> GetAllAsync()
        {
            try
            {
                var entities = await _countryRepository.GetAllList();
                return entities.Select(c => new ReedCountryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ISOCode = c.ISOCode
                }).ToList();
            }
            catch
            {
                return [];
            }
        }

        // Leer con include
        public async Task<List<ReedCountryDto>> GetAllWithIncludeAsync()
        {
            try
            {
                var entities = await _countryRepository
                    .GetAllQuery()
                    .Include(c => c.Indicators)
                    .ToListAsync();

                return entities.Select(c => new ReedCountryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ISOCode = c.ISOCode,
                    IndicatorQuantity = c.Indicators != null ? c.Indicators.Count : 0
                }).ToList();
            }
            catch
            {
                return [];
            }
        }

        // Leer por ID
        public async Task<ReedCountryDto?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _countryRepository.GetById(id);
                if (entity == null) return null;

                return new ReedCountryDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ISOCode = entity.ISOCode
                };
            }
            catch
            {
                return null;
            }
        }

        // Actualizar
        public async Task<bool> UpdateAsync(UpdateCountryDto dto)
        {
            try
            {
                var entity = new Country { Id = dto.Id, Name = dto.Name, ISOCode = dto.ISOCode };
                var returnEntity = await _countryRepository.UpdateAsync(entity.Id, entity);
                return returnEntity != null;
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
                await _countryRepository.DeleteAsync(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
