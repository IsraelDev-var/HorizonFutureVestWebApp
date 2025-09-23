

namespace Persistence.Entities
{
    public class Macroindicator
    {

        public required int Id { get; set; }
        public required string Name { get; set; }
        public required decimal  Weight { get; set; } // validación: suma total ≤ 1

        public required bool HigherIsBetter { get; set; }

        // relacion
        // 1 ----- *
        public ICollection<MacroindicatorSimulation>? MacroindicatorSimulations { get; set; }

        public ICollection<IndicatorsByCountry>? Indicators { get; set; }

    }
}
