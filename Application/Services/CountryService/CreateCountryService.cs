
using Application.Dtos.CountryDto;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries;

namespace Application.Services.CountryService
{
     public class CreateCountryService(AppContextDB appContextDB)
    {
        private readonly CountryRepository _countryRepository = new(appContextDB);

        // Agregar pais
        public async Task<bool> AddAsync(CreateCountryDto dto)
        {
            try
            {
                Country entity = new Country() { Id = 0, Name = dto.Name, ISOCode = dto.ISOCode };
                Country? returmEntity = await _countryRepository.AddAsync(entity);

                if (returmEntity != null)
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




    }
}
