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
        /// <summary>
        /// thêm category
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task AddAsync(JobDTO job)
        {
            var addjob = _mapper.Map<Job>(job);
            await _JobRepository.AddAsync(addjob);
        }
        /// <summary>
        /// xóa category
        /// </summary>
        /// <param name="idJob"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int idJob)
        {
            await _JobRepository.DeleteAsync(idJob);
            return idJob;
        }
        /// <summary>
        /// lấy tất cả danh sách category
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<JobDTO>> GetAllAsync()
        {
            #region MyRegion
            //var abc = await _JobRepository.GetAllAsync();
            //var productDtos = abc.Select(p => new JobDTOGetAll
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Content = p.Content,
            //    DateStart = p.DateStart,
            //    Status = p.Status,
            //    CategoryName = p.Category!.Name
            //});
            #endregion

            var getJob = await _JobRepository.GetAllAsync();
           
            var productDtos = _mapper.Map<IEnumerable<JobDTO>>(getJob);
                return productDtos;
        }
        /// <summary>
        /// lấy category theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JobDTO> GetByIdAsync(int id)
        {
            var getbyidJob = await _JobRepository.GetByIdAsync(id);
            return _mapper.Map<JobDTO>(getbyidJob);
        }
        /// <summary>
        /// lọc category theo status hoặc ngày
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        public async Task<IEnumerable<JobDTO>> GetByStatusDateStatusAsync(bool status, DateTime dateStart)
        {
           var getbatstatusDate=await _JobRepository.GetByStatusDateStatusAsync(status, dateStart);

            return _mapper.Map<IEnumerable<JobDTO>>(getbatstatusDate);
        }
        /// <summary>
        /// sửa category
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task UpdateAsync(JobDTO job)
        {
            var updateJob = _mapper.Map<Job>(job);
            await _JobRepository.UpdateAsync(updateJob);
        }
        /// <summary>
        /// add list category
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task AddListJob(IEnumerable<JobDTO> job)
        {
            var up = _mapper.Map<List<Job>>(job);
            await _JobRepository.AddListJob(up);
        }
        /// <summary>
        /// sửa list category
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public async Task UpdateListJob(IEnumerable<JobDTO> job)
        {
            var updateJob = _mapper.Map<List<Job>>(job);
            await _JobRepository.UpdateListJob(updateJob);
        }

       
    }
}
