using JobNetCore6.DTOs.User;
using JobNetCore6.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

namespace JobNetCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authrService;

        public AuthorsController(IAuthorService authorService) { _authrService = authorService; }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTo)
        { 
            var repon = await _authrService.Register(registerDTo);
           return Ok(repon);

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var response = await _authrService.Login(loginDTO);
            return new JsonResult(response);
        }
    }
}
