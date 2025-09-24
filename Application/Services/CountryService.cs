

using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries;

namespace Application.Services
{
    public class CountryService
    {
        private  readonly CoutryRepository _countryRepository;

        public CountryService(AppContextDB contextDB)
        {
            _countryRepository = new CoutryRepository(contextDB);
        }


        // Agregar pais
        public async Task<bool> AddAsync(CountryDto dto)
        {
            try
            {
                Country entity =  new Country() { Id = 0, Name = dto.Name, ISOCode = dto.ISOCode };
                Country? returmEntity = await _countryRepository.AddAsync(entity);

                if (returmEntity != null)
                {
                    return true;
                }

                return false;

            }catch (Exception) 
            {
                return false;
            }
        }

        // Actulizar pais
        public async Task<bool> UpdateAsync(CountryDto dto)
        {
            try
            {
                Country entity = new() { Id = 0, Name = dto.Name, ISOCode = dto.ISOCode };
                Country? returnEntity = await _countryRepository.UpdateAsync(entity.Id, entity);
                if (returnEntity != null)
                {
                    return true;

                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Eliminar Pais

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _countryRepository.DeleteAsync(id);
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        // obtener por el ID
        public async Task<CountryDto?> GetById(int id)
        {
            try
            {
                var entity = await _countryRepository.GetById(id);
                if (entity != null)
                {
                    CountryDto dto = new() { Id = entity.Id, Name = entity.Name, ISOCode = entity.ISOCode };

                    return dto;
                }
                return null;
            }catch(Exception) 
            {
                return null;
            }
        }

        // obtener todos

        public async Task<List<CountryDto>> GetAllList()
        {
            try
            {
                var entitiesList = await _countryRepository.GetAllListAsync();

                var entityListDto = entitiesList.Select(c =>
                new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ISOCode = c.ISOCode
                }).ToList();

                return entityListDto;
            }
            catch (Exception)
            {
                return [];
            }
        }


        public async Task<List<CountryDto>> GetAllWithInclude()
        {
            try
            {
                var entitiesQuery =  _countryRepository.GetAllQuery();

                var entitiesList = await entitiesQuery.Include(c => c.Indicators).ToListAsync();

                var entityListDto = entitiesList.Select( c => 
                new CountryDto {
                    Id = c.Id, 
                    Name = c.Name, 
                    ISOCode = c.ISOCode ,
                    IndicatorQuantity = c.Indicators != null ? c.Indicators.Count : 0, // operadot ternario
                }).ToList();
                return entityListDto;
            }
            catch (Exception) 
            {
                return [];
            }
        }









    }
}
