namespace Persistence.Repositpries.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> AddAsync(T country);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllList();
        IQueryable<T> GetAllQuery();
        Task<T?> GetById(int id);
        Task<T?> UpdateAsync(int id, T country);
    }
}