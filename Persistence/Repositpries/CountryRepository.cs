
using Persistence.Contexts;
using Persistence.Entities;

namespace Persistence.Repositpries
{
    public class CountryRepository(AppContextDB contextDB) : GenericRepository<Country>(contextDB)
    {
        private new readonly AppContextDB _contextDB = contextDB;
    }
}
