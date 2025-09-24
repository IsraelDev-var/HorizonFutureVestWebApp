

using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;

namespace Persistence.Repositpries
{
    public class CoutryRepository
    {
        private readonly AppContextDB _contextDB;

        public CoutryRepository(AppContextDB country) 
        {
            _contextDB = country;
        
        }


        // Agregar pais
        public async Task<Country> AddAsync(Country country)
        {

            await _contextDB.Set<Country>().AddAsync(country);
            await _contextDB.SaveChangesAsync();
            return country;
        }
        // Actualiza pais
        public async Task<Country?> UpdateAsync(int id, Country country)
        {

            var entry = await _contextDB.Set<Country>().FindAsync(id);

            if (entry != null)
            {

                _contextDB.Entry(entry).CurrentValues.SetValues(country);

                await _contextDB.SaveChangesAsync();
                return entry;
            }
            return null;
        }

        // Eliminar pais
        public async Task DeleteAsync(int id)
        {

            var entity = await _contextDB.Set<Country>().FindAsync(id);

            if (entity != null)
            {
                _contextDB.Set<Country>().Remove(entity);
                await _contextDB.SaveChangesAsync();
                
            }
            
        }

        // obtener paises

       
        public async Task<List<Country>> GetAllListAsync()
        {
            return await _contextDB.Set<Country>().ToListAsync();
        }

        public async Task<Country?> GetById(int id)
        {
            return await _contextDB.Set<Country>().FindAsync(id);
           
        }

        public IQueryable<Country> GetAllQuery()
        {
            return _contextDB.Set<Country>().AsQueryable();
        }

        
    }
}
