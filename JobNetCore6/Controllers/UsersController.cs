using JobNetCore6.DTOs.User;
using JobNetCore6.Entities;
using JobNetCore6.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobNetCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService) { _userService = userService; }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUser()
        {
            var getall = await _userService.GetAll();
            return Ok(getall);

        }

        [HttpPost]
        public async Task<ActionResult> add( AppUserDTO appUser)
        {
           await _userService.Create( appUser);
            return Ok(appUser);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(Guid? id)
        {
            var deleteUser = _userService.GetById(id);
          
            await _userService.Delete(id);
            
              
          
            return Ok(deleteUser.Id);
           
        }
    }
}
