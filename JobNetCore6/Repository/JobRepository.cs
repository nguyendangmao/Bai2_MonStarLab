using Castle.Core.Internal;
using JobNetCore6.Core.Models;
using JobNetCore6.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;

namespace JobNetCore6.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDBContext _context;

        public JobRepository(AppDBContext context) { _context = context; }

        public async Task AddAsync(Job job)
        {
             _context.Jobs!.Add(job);
             await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int idJob)
        {
            var delete = _context.Jobs!.SingleOrDefault(b => b.Id == idJob);
            if (delete != null)
            {
                _context.Jobs!.Remove(delete);
                await _context.SaveChangesAsync();
            }
            return delete.Id;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await   _context.Jobs!.Include(n=>n.Category).ToListAsync();
        }

        public async Task<Job> GetByIdAsync(int id)
        {
           var getbyid =  await _context.Jobs!.FindAsync(id);
            return getbyid!;
        }

        public async Task<IEnumerable<Job>> GetByStatusDateStatusAsync(bool status, DateTime dateStart)
        {
            return await _context.Jobs!.Where(n => n.Status.Equals( status) || n.DateStart.Equals( dateStart)).OrderBy(n=>n.DateStart).ToArrayAsync();

        }

        public async Task UpdateAsync(Job job)
        {
            _context.Jobs!.Update(job);
            await _context.SaveChangesAsync();
        }

        public async Task AddListJob(IEnumerable<Job> job)
        {
                await _context.Jobs!.AddRangeAsync(job);
                await _context.SaveChangesAsync();
        }

        public async Task UpdateListJob(IEnumerable<Job> job)
        {       
                _context.Jobs!.UpdateRange(job);
                await _context.SaveChangesAsync();
        }
    }
}
