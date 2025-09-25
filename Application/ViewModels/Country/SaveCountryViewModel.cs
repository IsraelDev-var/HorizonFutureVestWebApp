using System.ComponentModel.DataAnnotations;
namespace Application.ViewModels.Country
{
    public class SaveCountryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio ")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "El codigo ISO es Obligatorio ")]
        public required string ISOCode { get; set; }

    }
}
