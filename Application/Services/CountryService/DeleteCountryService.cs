using Application.Dtos.CountryDto;
using Persistence.Contexts;
using Persistence.Repositpries;

namespace Application.Services.CountryService
{
    public  class DeleteCountryService(AppContextDB contextDB)
    {
        private readonly CountryRepository _countryRepository = new(contextDB);

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
        public async Task<ReedCountryDto?> GetById(int id)
        {
            try
            {
                var entity = await _countryRepository.GetById(id);
                if (entity != null)
                {
                    ReedCountryDto dto = new() { Id = entity.Id, Name = entity.Name, ISOCode = entity.ISOCode };

                    return dto;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
