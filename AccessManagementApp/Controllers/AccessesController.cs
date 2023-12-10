using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccessesController : ControllerBase
    {
        private readonly IAccessService _accessService;

        public AccessesController(IAccessService accessService)
        {
            _accessService = accessService;
        }
        // GET: api/<AccessesController>
        [HttpGet("all")]
        public async Task<ActionResult<ICollection<Access>>> GetAll()
        {
            var accesses = await _accessService.GetAll();
            return Ok(accesses);
        }

        // GET api/<AccessesController>/5
        [HttpGet("access/{id}")]
        public async Task<ActionResult<Access>> GetById(int id)
        {
            var access = await _accessService.GetById(id);
            if(access == null)
            {
                return NotFound($"Access with ID {id} not found");
            }
            return Ok(access);
        }

        // GET api/<AccessesController>/5
        [HttpGet("filterAccesses/{query}")]
        public async Task<ActionResult<ICollection<Access>>> GetFilteredData(string query)
        {
            var filteredAccesses = await _accessService.GetFilteredAccesses(query);
            return Ok(filteredAccesses);

        }
    }
}
