

namespace Application.Dtos.MacroindicatorDto
{
    public class ReedMacroindicatorDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Weight { get; set; } // validación: suma total ≤ 1

        public  bool HigherIsBetter { get; set; }
    }
}
