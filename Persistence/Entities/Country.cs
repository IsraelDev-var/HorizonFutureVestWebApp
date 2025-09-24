

namespace Persistence.Entities
{
    public class Country
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string ISOCode { get; set; }

        

        // relacione 
        //  1 ------ *

        public ICollection<IndicatorsByCountry>? Indicators { get; set; }


        
    }
}
