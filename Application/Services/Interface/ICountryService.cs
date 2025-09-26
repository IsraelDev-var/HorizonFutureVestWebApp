using Application.Dtos.CountryDto;

namespace Application.Services.Interface
{
    public interface ICountryService : IGenericService<CreateCountryDto, ReedCountryDto, UpdateCountryDto>
    {
    }
}
