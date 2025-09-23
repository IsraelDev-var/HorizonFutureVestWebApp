using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class IndicatorsByCountry
    {
        public required int Id { get; set; }
        
        public required Decimal Value { get; set; }
        public required DateOnly Year { get; set; }

        // Restricción: no puede existir el mismo macroindicador dos veces para el mismo país en un año.

        // relacion
        public required int CountryId { get; set; }
        public required int MacroindicatorId { get; set; }

        // navigation property

        public required Country Country { get; set; }

        public required Macroindicator Macroindicator { get; set; }



    }
}
