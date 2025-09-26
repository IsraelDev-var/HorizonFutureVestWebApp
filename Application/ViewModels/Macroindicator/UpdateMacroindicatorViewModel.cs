using System.ComponentModel.DataAnnotations;
namespace Application.ViewModels.Macroindicator

{
    public class UpdateMacroindicatorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio ")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "El Peso es Obligatorio ")]
        public required decimal Weight { get; set; } // validación: suma total ≤ 1

        [Required(ErrorMessage = "El es 'Mas Alto' Obligatorio ")]
        public required bool HigherIsBetter { get; set; }

    }
}
