using JobNetCore6.DTOs;
using JobNetCore6.DTOs.Request;
using JobNetCore6.Entities;
using JobNetCore6.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobNetCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService) {
            _categoryService=categoryService;
        }
        /// <summary>
        /// get tất cả thể loại
        /// </summary>
        /// <returns></returns>
   
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var cateDtos = await _categoryService.GetAllAsync();
            return Ok(cateDtos);
        }
        /// <summary>
        /// get the loai thei id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cateDtos = await _categoryService.GetByIdAsync(id);
            return Ok(cateDtos);
        }
        /// <summary>
        /// add thể loại
        /// </summary>
        /// <param name="cateDtos"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddAsync([FromBody] ResquestCategoryAdd cateDtos)
        {
          
            return Ok(await _categoryService.AddAsync(cateDtos));
        }
        /// <summary>
        /// update 1 sản phẩm
        /// </summary>
        /// <param name="cateDtos"></param>
        /// <returns></returns>
        [HttpPut]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateAsync([FromBody] CategoryDTO cateDtos)
        {
            await _categoryService.UpdateAsync(cateDtos);
            return Ok();
        }
        /// <summary>
        /// xoa 1 task thể loại
        /// </summary>
        /// <param name="idcate"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteAsync(int  id)
        {
            var product = await _categoryService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteAsync(id);

            return Ok(product.Id);

        }

    }
}
