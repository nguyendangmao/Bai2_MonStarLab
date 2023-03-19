using JobNetCore6.Core.Models;

namespace JobNetCore6.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        public Task DeleteAsync(int id);
    }
}
