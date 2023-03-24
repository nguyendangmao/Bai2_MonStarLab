using AutoMapper;
using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;
using JobNetCore6.DTOs.Request;
using JobNetCore6.DTOs.Respone;
using JobNetCore6.DTOs.User;
using JobNetCore6.Entities;

namespace JobNetCore6.Automappe
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();   
            CreateMap<Job, JobDTO>().ReverseMap();
            CreateMap<JobDTO, Job>().ReverseMap();
            CreateMap<CategoryDTOSUa, Category>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<AppUserDTO, AppUser>().ReverseMap();

            CreateMap<AppUser, LoginDTO>()
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dto => dto.Password, opt => opt.MapFrom(src => src.Password)).ReverseMap();
            CreateMap<AppUser, ResponeUserGetAll>()
                //.ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(src => src.Name)).ReverseMap();
                 //.ForMember(dto => dto.UserName, opt => opt.MapFrom(src => src.Name))
                ;
            CreateMap<ResquestCategoryAdd, ResponeCategory>().ReverseMap();
            CreateMap<Category, ResquestCategoryAdd>().ReverseMap();
            CreateMap<Category, ResponeCategory>().ReverseMap();
            CreateMap<AppUser, ResponeUser>().ReverseMap();

        }

    }
}
