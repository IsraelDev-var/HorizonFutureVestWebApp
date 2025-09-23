

namespace Persistence.Entities
{
    public class MacroindicatorSimulation
    {
        public required int Id { get; set; }
        public required int SimulationWeight { get; set; }

        // Relacion
        public required int MacroindicatorId { get; set; } // FK 

        //navigatoin property
        public Macroindicator? Macroindicator { get; set; }



    }
}
