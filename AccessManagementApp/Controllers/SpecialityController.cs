using AccessManagementApp.Entities;
using AccessManagementApp.Models;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Classes;
using AccessManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        // GET: api/<SpecialityController>
        [HttpGet("all")]
        public async Task<ActionResult<Speciality>> GetAll()
        {
            try
            {
                var specialities = await _specialityService.GetAll();
                return Ok(specialities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/<SpecialityController>/5
        [HttpGet("speciality/{id}")]
        public async Task<ActionResult<Speciality>> GetById(int id)
        {
            try
            {
                var speciality = await _specialityService.GetById(id);

                if (speciality == null)
                {
                    return NotFound($"Speciality with ID {id} not found");
                }

                return Ok(speciality);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filterSpecialities/{query}")]
        public async Task<ActionResult<ICollection<Speciality>>> GetFilteredSpecialities(string query)
        {
            try
            {
                var specialities = await _specialityService.GetFilteredSpecialities(query);
                return Ok(specialities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<SpecialityController>/5
        [HttpPut("update")]
        public async Task<ActionResult<SpecialityModel>> Update([FromBody] UpdateSpecialityModel specialityModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingSpeciality = await _specialityService.GetById(specialityModel.Id);
                if (existingSpeciality == null)
                {
                    return NotFound();
                }

                var updatedSpeciality = await _specialityService.Update(specialityModel);
                return Ok(updatedSpeciality);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error.\n\n{ex}");
            }
        }
    }
}
