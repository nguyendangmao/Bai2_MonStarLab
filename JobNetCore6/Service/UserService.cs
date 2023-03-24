using AutoMapper;
using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;
using JobNetCore6.DTOs.Respone;
using JobNetCore6.DTOs.User;
using JobNetCore6.Entities;
using JobNetCore6.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobNetCore6.Service
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        public readonly IUserRepository _userrepository;
        public UserService(IUserRepository serviceAppuser, IMapper mapper)
        {
            _userrepository = serviceAppuser;
            _mapper=mapper;

        }
        public async Task<AppUserDTO> Create(AppUserDTO _object)
        {
            var cate = _mapper.Map<AppUser>(_object);
            await _userrepository.Create(cate);

            return _object;
        }

        public async Task Delete(Guid? id)
        {
            await _userrepository.Delete(id);
        }

        public async Task<AppUserDTO> Update( AppUserDTO _object)
        {
            var cate = _mapper.Map<AppUser>(_object);
            await _userrepository.Update( cate);
            return _object;
        }

        public async Task<IEnumerable<ResponeUser>> GetAll()
        {
            var cate = await _userrepository.GetAll();
            return   _mapper.Map<IEnumerable<ResponeUser>>(cate);
        }
       
        public async Task<AppUserDTO> GetById(Guid? Id)
        {
            var cate = await _userrepository.GetById(Id);
            return _mapper.Map<AppUserDTO>(cate);
        }
    }
}
