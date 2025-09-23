

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistence.Entities
{
    public class RankingResult
    {
        public required int CountryId { get; set; }
        public required int ISOCodeId { get; set; }
        public required Decimal Scoring { get; set; }
        public required Decimal EstimatedRateofReturn { get; set; }
    }
}
