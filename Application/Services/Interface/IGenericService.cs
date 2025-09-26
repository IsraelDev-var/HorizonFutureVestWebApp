

namespace Application.Services.Interface
{
    public interface IGenericService<TCreateDto, TReadDto, TUpdateDto>
    {
        Task<bool> CreateAsync(TCreateDto dto);
        Task<List<TReadDto>> GetAllAsync();
        Task<List<TReadDto>> GetAllWithIncludeAsync();
        Task<TReadDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
