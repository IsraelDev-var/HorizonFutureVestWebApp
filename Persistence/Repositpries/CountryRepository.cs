
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries.Interface;

namespace Persistence.Repositpries
{
    public class CountryRepository(AppContextDB contextDB) : GenericRepository<Country>(contextDB), ICountryRepository
    {
        private new readonly AppContextDB _contextDB = contextDB;
    }
}
