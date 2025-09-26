
namespace Application.Dtos.MacroindicatorDto
{
    public  class CreateMacroindicatorDto
    {
        public required string Name { get; set; }
        public required decimal Weight { get; set; } // validación: suma total ≤ 1

        public required bool HigherIsBetter { get; set; }

    }
}
