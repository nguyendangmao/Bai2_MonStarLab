using JobNetCore6.Core.Models;
using JobNetCore6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CategoryRepositoryMock : ICategoryRepository
    {
        private readonly List<Category> _category;

        public CategoryRepositoryMock()
        {
            _category = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2"},
                new Category { Id = 3, Name = "Category 3" },
                new Category { Id = 4, Name = "Category 4" },
                new Category { Id = 5, Name = "Category 5"},
                new Category { Id = 6, Name = "Category 6" }
            };
        }

        public async Task<Category> AddAsync(Category category)
        {
            category.Id = _category.Max(p => p.Id) + 1;
            _category.Add(category);
            await Task.CompletedTask;
            return category;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            _category.Remove(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await Task.FromResult(_category);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await Task.FromResult(_category.FirstOrDefault(p => p.Id == id));
        }

        public async Task UpdateAsync(Category category)
        {
            var index = _category.FindIndex(p => p.Id == category.Id);
            _category[index] = category;
            await Task.CompletedTask;
        }
    }
}
