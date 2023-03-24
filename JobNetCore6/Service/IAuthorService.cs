using JobNetCore6.DTOs.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JobNetCore6.Service
{
    public interface IAuthorService
    {
        public JwtSecurityToken GetToken(List<Claim> authClaims);
        public Task<Object> Login(LoginDTO logindto);
        public Task<Response> Register(RegisterDTO registerdto);
    }
}
