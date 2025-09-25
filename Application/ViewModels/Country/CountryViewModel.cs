

namespace Application.ViewModels.Country
{
    public class CountryViewModel
    {
        public  int Id { get; set; }
        public required string Name { get; set; }
        public  string? ISOCode { get; set; }

        public int? IndicatorQuantity { get; set; }
    }
}
