

using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries.Interface;

namespace Persistence.Repositpries
{
    public class GenericRepository<T>(AppContextDB appContextDB) : IGenericRepository<T> where T : class
    {

        protected readonly AppContextDB _contextDB = appContextDB;


        // Agregar pais
        public async Task<T?> AddAsync(T country)
        {

            await _contextDB.Set<T>().AddAsync(country);
            await _contextDB.SaveChangesAsync();
            return country;
        }
        // Actualiza pais
        public async Task<T?> UpdateAsync(int id, T country)
        {

            var entry = await _contextDB.Set<T>().FindAsync(id);

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

            var entity = await _contextDB.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _contextDB.Set<T>().Remove(entity);
                await _contextDB.SaveChangesAsync();

            }

        }

        // obtener paises


        public async Task<List<T>> GetAllList()
        {
            return await _contextDB.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _contextDB.Set<T>().FindAsync(id);

        }

        public IQueryable<T> GetAllQuery()
        {
            return _contextDB.Set<T>().AsQueryable();
        }


    }
}
