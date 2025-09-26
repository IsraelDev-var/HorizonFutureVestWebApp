using System.ComponentModel.DataAnnotations;
namespace Application.ViewModels.Macroindicator

{
    public class UpdateMacroindicatorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio ")]
        public required string Name { get; set; }
        
        public required decimal Weight { get; set; } // validación: suma total ≤ 1

        [Required(ErrorMessage = "Debe seleccionar si es más alto mejor")]
        public  bool HigherIsBetter { get; set; }

    }
}
