namespace Application.Dtos.CountryDto
{
    public class ReedCountryDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ISOCode { get; set; }

        public int? IndicatorQuantity { get; set; }
    }
}
