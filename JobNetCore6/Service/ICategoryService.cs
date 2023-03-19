using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;

namespace JobNetCore6.Service
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task AddAsync(CategoryDTOSUa categoryDTO);
        Task UpdateAsync(CategoryDTO categoryDTO);
        public Task DeleteAsync(int id);
    }
}
