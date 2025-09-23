

namespace Persistence.Entities
{
    public class ReteOfReturn
    {
        public required int Id { get; set; }
        public required Decimal MinimunRete {  get; set; }
        public required Decimal MaximunRete { get; set; }

    }
}
