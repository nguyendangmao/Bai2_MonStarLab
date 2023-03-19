using AutoMapper;
using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;

namespace JobNetCore6.Automappe
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();   
            CreateMap<Job, JobDTO>();
            CreateMap<JobDTO, Job>();
            CreateMap<CategoryDTOSUa, Category>();
        }

    }
}
