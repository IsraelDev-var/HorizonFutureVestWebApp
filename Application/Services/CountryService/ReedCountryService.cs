using Application.Dtos.CountryDto;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries;

namespace Application.Services.CountryService
{
    public class ReedCountryService(AppContextDB contextDB)
    {
        private  readonly CountryRepository _countryRepository = new CountryRepository(contextDB);

        
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
