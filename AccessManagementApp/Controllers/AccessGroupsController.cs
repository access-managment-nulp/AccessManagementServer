using AccessManagementApp.Entities;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Classes;
using AccessManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccessGroupsController : ControllerBase
    {
        private readonly IAccessGroupService _accessGroupService;

        public AccessGroupsController(IAccessGroupService accessGroupService)
        {
            _accessGroupService = accessGroupService;
        }

        // GET: api/<AccessGroupController>
        [HttpGet("all")]
        public async Task<ActionResult<ICollection<AccessGroup>>> GetAll()
        {
            var accessGroups = await _accessGroupService.GetAll();
            return Ok(accessGroups);
        }

        // GET api/<AccessGroupController>/5
        [HttpGet("accessGroup/{id}")]
        public async Task<ActionResult<AccessGroup>> GetById(int id)
        {
            var accessGroup = await _accessGroupService.GetById(id);

            if (accessGroup == null)
            {
                return NotFound($"Access Group with ID {id} not found");
            }
            return Ok(accessGroup);

        }

        // GET api/<AccessGroupController>/5
        [HttpGet("filterAccessGroups/{query}")]
        public async Task<ActionResult<ICollection<AccessGroup>>> GetFilteredAccessGroups(string query)
        {
            var filteredGroups = await _accessGroupService.GetFilteredAccessGroups(query);
            return Ok(filteredGroups);

        }

        // POST api/<AccessGroupController>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AccessGroupModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccessGroupModel>> Create([FromBody] CreateAccessGroupModel accessGroupModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdAccessGroup = await _accessGroupService.Create(accessGroupModel);
            return CreatedAtAction(nameof(GetById), new { id = createdAccessGroup.Id }, createdAccessGroup);
            
        }

        // PUT api/<AccessGroupController>/5
        [HttpPut("update")]       
        public async Task<ActionResult<AccessGroupModel>> Update([FromBody] UpdateAccessGroupModel accessGroupModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingAccessGroup = await _accessGroupService.GetById(accessGroupModel.Id);
            if (existingAccessGroup == null)
            {
                return NotFound();
            }
            
            var updatedAccessGroup = await _accessGroupService.Update(accessGroupModel);
            return Ok(updatedAccessGroup);
        }

        // DELETE api/<AccessGroupController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccessGroup>> Delete(int id)
        {
            var deletedAccessGroup = await _accessGroupService.Delete(id);
            if (deletedAccessGroup != null)
            {
                return Ok(deletedAccessGroup);
            }
            else
            {
                return NotFound($"Access Group with ID {id} not found");
            }
        }
    }
}
