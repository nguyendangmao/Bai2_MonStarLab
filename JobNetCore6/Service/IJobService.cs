using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;
using JobNetCore6.Entities;

namespace JobNetCore6.Service
{
    public interface IJobService
    {
        public Task<JobDTO> GetByIdAsync(int id);
        public Task<IEnumerable<JobDTO>> GetAllAsync();
        public Task AddAsync(JobDTO job);
        public Task UpdateAsync(JobDTO job);

        public Task<int> DeleteAsync(int idJob);
        Task<IEnumerable<JobDTO>> GetByStatusDateStatusAsync(bool status, DateTime dateStart);
        public Task AddListJob(IEnumerable<JobDTO> job);
        public Task UpdateListJob(IEnumerable<JobDTO> job);
    }
}
