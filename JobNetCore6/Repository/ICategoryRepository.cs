using JobNetCore6.Core.Models;
using JobNetCore6.DTOs.Respone;

namespace JobNetCore6.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> AddAsync(Category category);
        Task UpdateAsync(Category category);
        public Task DeleteAsync(int id);
    }
}
