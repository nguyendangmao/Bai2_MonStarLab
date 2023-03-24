using JobNetCore6.Core.Models;

namespace JobNetCore6.Repository
{
    public interface IJobRepository
    {
        Task<Job> GetByIdAsync(int id);
        Task<IEnumerable<Job>> GetAllAsync();
        Task AddAsync(Job job);
        Task UpdateAsync(Job job);
        public Task<int> DeleteAsync(int idJob);
        Task<IEnumerable<Job>> GetByStatusDateStatusAsync(bool status,DateTime dateStart);
        public Task AddListJob(IEnumerable<Job> job);
        public Task UpdateListJob(IEnumerable<Job> job);

    }
}
