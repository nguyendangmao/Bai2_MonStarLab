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
    public class AuthorService : IAuthorService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;
        public readonly IUserRepository _userrepository;
        public AuthorService(IUserRepository userrepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userrepository = userrepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;

        }


        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<object> Login(LoginDTO logindto)
        {
           
            var user = await _userManager.FindByNameAsync(logindto.UserName);

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim> {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var token = GetToken(authClaims);
            return new
            {
                api_key = new JwtSecurityTokenHandler().WriteToken(token),
                #region MyRegion
                //expiration = token.ValidTo,
                //user = user,
                //Role = userRoles,
                //status = "User Login Successfully"
                #endregion

            };
        }

        public async Task<DTOs.User.Response> Register(RegisterDTO registerdto)
        {
            var IsExist = await _userManager.FindByNameAsync(registerdto.Name);
            if (IsExist != null)
            return new DTOs.User.Response
            {
                Status = "Error",
                Message = "Not already exists!"
            };
            var mk = EncodePasswordToBase64(registerdto.Password!);
            AppUser appUser = new AppUser
            {
                UserName = registerdto.Name,
                Password = mk,
                UserRole = registerdto.UserRole,
                IsDeleted = registerdto.IsDeleted
            };
            
            var result = await _userManager.CreateAsync(appUser, registerdto.Password);
            if (!result.Succeeded) return new DTOs.User.Response
            {
                Status = "Error",
                Message = "User creation failed! Please check user details and try again."
            };
            if (!await _roleManager.RoleExistsAsync(registerdto.UserRole)) await _roleManager.CreateAsync(new IdentityRole(registerdto.UserRole));
            if (await _roleManager.RoleExistsAsync(registerdto.UserRole))
            {
                await _userManager.AddToRoleAsync(appUser, registerdto.UserRole);
            }
            return new DTOs.User.Response
            {
                Status = "Success",
                Message = "User created successfully!"
            };
        }

        public  string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Convert to Decord your Password
        //public string DecodeFrom64(string encodedData)
        //{
        //    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        //    System.Text.Decoder utf8Decode = encoder.GetDecoder();
        //    byte[] todecode_byte = Convert.FromBase64String(encodedData);
        //    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        //    char[] decoded_char = new char[charCount];
        //    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        //    string result = new String(decoded_char);
        //    return result;
        //}
    }
}
