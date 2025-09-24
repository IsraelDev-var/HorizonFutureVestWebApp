

namespace Application.DTOs
{
    public class CountryDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ISOCode { get; set; }

        public int? IndicatorQuantity { get; set; }
    }
}
