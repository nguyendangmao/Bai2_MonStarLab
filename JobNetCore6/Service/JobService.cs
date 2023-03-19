using AutoMapper;
using JobNetCore6.Core.Models;
using JobNetCore6.Repository;


using JobNetCore6.DTOs;

namespace JobNetCore6.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _JobRepository;
        private readonly IMapper _mapper;

        public JobService(IJobRepository JobRepository, IMapper mapper)
        {
            _JobRepository = JobRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(JobDTO job)
        {
            var addjob = _mapper.Map<Job>(job);
            await _JobRepository.AddAsync(addjob);
        }

        public async Task DeleteAsync(int idJob)
        {
            await _JobRepository.DeleteAsync(idJob);
        }

        public async Task<IEnumerable<JobDTO>> GetAllAsync()
        {
            var getJob = await _JobRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<JobDTO>>(getJob);
        }

        public async Task<JobDTO> GetByIdAsync(int id)
        {
            var getbyidJob = await _JobRepository.GetByIdAsync(id);
            return _mapper.Map<JobDTO>(getbyidJob);
        }

        public async Task<IEnumerable<JobDTO>> GetByStatusDateStatusAsync(bool status, DateTime dateStart)
        {
           var getbatstatusDate=await _JobRepository.GetByStatusDateStatusAsync(status, dateStart);

            return _mapper.Map<IEnumerable<JobDTO>>(getbatstatusDate);
        }

        public async Task UpdateAsync(JobDTO job)
        {
            var updateJob = _mapper.Map<Job>(job);
            await _JobRepository.UpdateAsync(updateJob);
        }

        public async Task AddListJob(IEnumerable<JobDTO> job)
        {
            var up = _mapper.Map<List<Job>>(job);
            await _JobRepository.AddListJob(up);
        }

        public async Task UpdateListJob(IEnumerable<JobDTO> job)
        {
            var updateJob = _mapper.Map<List<Job>>(job);
            await _JobRepository.UpdateListJob(updateJob);
        }
    }
}
