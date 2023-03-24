using JobNetCore6.DTOs.Respone;
using JobNetCore6.DTOs.User;
using JobNetCore6.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JobNetCore6.Service
{
    public interface IUserService
    {

        public Task<AppUserDTO> Create(AppUserDTO _object);
        public Task Delete(Guid? id);
        public Task<AppUserDTO> Update(AppUserDTO _object);
        public Task<IEnumerable<ResponeUser>> GetAll();
        public Task<AppUserDTO> GetById(Guid? Id);
    }
}
