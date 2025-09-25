
using Application.Dtos.CountryDto;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries;


namespace Application.Services.CountryService
{
    public class UpdateCountryService(AppContextDB appcontextDB)
    {
        
        private readonly CountryRepository _countryRepository = new(appcontextDB);

        public async Task<bool> UpdateAsync(CountryDto dto)
        {
            try
            {
                Country entity = new() { Id = dto.Id, Name = dto.Name, ISOCode = dto.ISOCode };
                Country? returnEntity = await _countryRepository.UpdateAsync(entity.Id, entity);
                if (returnEntity == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
