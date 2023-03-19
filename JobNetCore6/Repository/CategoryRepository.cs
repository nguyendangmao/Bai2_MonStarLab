using JobNetCore6.Core.Models;
using JobNetCore6.Entities;
using Microsoft.EntityFrameworkCore;
using Mysqlx;
using Org.BouncyCastle.Asn1.Nist;

namespace JobNetCore6.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;
       
        public CategoryRepository(AppDBContext context) {
            _context=context;
        }

        public async Task DeleteAsync(int id)
        {
            var delete = _context.Categories!.SingleOrDefault(b => b.Id == id);
            if (delete != null)
            {
                _context.Categories!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories!.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories!.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return  await _context.Categories!.FirstOrDefaultAsync(n=>n.Id==id);
           
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories!.Update(category);
            await _context.SaveChangesAsync();
        }

       
    }
}
