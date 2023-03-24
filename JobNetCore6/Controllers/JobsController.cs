using JobNetCore6.Core.Models;
using JobNetCore6.DTOs;
using JobNetCore6.DTOs.User;
using JobNetCore6.Entities;
using JobNetCore6.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobNetCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobservice;

        public JobsController(IJobService jobService) { _jobservice = jobService; }

         /// <summary>
         /// get job theo ngy,status
         /// </summary>
         /// <param name="status"></param>
         /// <param name="dateStart"></param>
         /// <returns></returns>
        [HttpGet("GetByStatusDate")]
        public async Task<IActionResult> GetByStatusDateStatusAsync(bool status,DateTime dateStart)
        {
            var cateDtos = await _jobservice.GetByStatusDateStatusAsync(status, dateStart);
            return Ok(cateDtos);
        }
        /// <summary>
        /// get tat ca job
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var jobDtos = await _jobservice.GetAllAsync();
            return Ok(jobDtos);
        }
        /// <summary>
        /// get job theo id
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var jobDtos = await _jobservice.GetByIdAsync(id);
            if (jobDtos == null)
            {
                return NotFound();
            }
            return Ok(jobDtos);
        }
        /// <summary>
        /// them 1 task
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles =UserRoles.Admin)]
        [AllowAnonymous]
        public async Task<IActionResult> AddAsync([FromBody] JobDTO jobDtos)
        {
            await _jobservice.AddAsync(jobDtos);
            return Ok(jobDtos);
        }
        /// <summary>
        /// sua 1 task
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync([FromBody] JobDTO jobDto)
        {
            await _jobservice.UpdateAsync(jobDto);
            return Ok(jobDto);
        }
        /// <summary>
        /// sua nhieu task
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        [HttpPut("Updates")]
        [Authorize(Roles = UserRoles.Admin)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateListJob(IEnumerable<JobDTO> jobDto)
        {
            await _jobservice.UpdateListJob(jobDto);
            return Ok(jobDto);
        }
        /// <summary>
        /// xoa 1 task
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        [Authorize(Roles = UserRoles.Admin)]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int idJob)
        {
            await _jobservice.DeleteAsync(idJob);
            return Ok(idJob);
        }


        [HttpPost("Adds")]
        [Authorize(Roles = UserRoles.Admin)]
        [AllowAnonymous]
        public async Task<IActionResult> AddlistJob(IEnumerable<JobDTO> jobDto)
        {
            await  _jobservice.AddListJob(jobDto);
            return Ok("succsec");
        }
    }
}
