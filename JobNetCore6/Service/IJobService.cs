using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;

namespace JobNetCore6.Service
{
    public interface IJobService
    {
        Task<JobDTO> GetByIdAsync(int id);
        Task<IEnumerable<JobDTO>> GetAllAsync();
        Task AddAsync(JobDTO job);
        Task UpdateAsync(JobDTO job);
        public Task DeleteAsync(int idJob);
        Task<IEnumerable<JobDTO>> GetByStatusDateStatusAsync(bool status, DateTime dateStart);
        public Task AddListJob(IEnumerable<JobDTO> job);
        public Task UpdateListJob(IEnumerable<JobDTO> job);
    }
}
