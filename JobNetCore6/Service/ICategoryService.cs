
using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;
using JobNetCore6.DTOs.Request;
using JobNetCore6.DTOs.Respone;

namespace JobNetCore6.Service
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<ResponeCategory> AddAsync(ResquestCategoryAdd categoryDTO);
        Task UpdateAsync(CategoryDTO categoryDTO);
        public Task DeleteAsync(int id);
    }
}
