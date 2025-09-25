

namespace Application.Dtos.CountryDto
{
    public class UpdateCountryDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ISOCode { get; set; }
    }
}
