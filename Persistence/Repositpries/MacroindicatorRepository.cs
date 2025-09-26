using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries.Interface;
using System.Threading.Tasks;

namespace Persistence.Repositpries
{
    public class MacroindicatorRepository(AppContextDB macroindicator) : GenericRepository<Macroindicator>(macroindicator), IMacroindicatorRepository
    {
        private new readonly AppContextDB _contextDB = macroindicator;

        
    }
}
