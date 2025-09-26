
using System.ComponentModel.DataAnnotations;
namespace Application.ViewModels.Macroindicator
{
    public class CreateMacroindicatorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio ")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "El peso es Obligatorio ")]
        
        public required decimal Weight { get; set; } // validación: suma total ≤ 1

        [Required(ErrorMessage = "El peso es Obligatorio ")]
        public  bool HigherIsBetter { get; set; }


    }


    
}
