namespace Application.ViewModels.Country
{
    public class ReedCountryViewModel
    {
        public  int Id { get; set; }
        public required string Name { get; set; }
        public required  string ISOCode { get; set; }

        public int? IndicatorQuantity { get; set; }
    }
}
