using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.API.Requests.Group;
using TestingPlatform.API.Responses.Group;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Infrastructure.Data;
using TestingPlatform.Infrastructure.Repositories;
using TestingPlatform.Models;

namespace TestingPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController(IGroupRepository groupRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await groupRepository.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<GroupResponse>>(groups));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var group = await groupRepository.GetByIdAsync(id);
            return Ok(mapper.Map<GroupResponse>(group));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest request)
        {
            // Request -> Dto
            var dto = mapper.Map<GroupDto>(request);
            var id = await groupRepository.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created, new { Id = id });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupRequest request)
        {
            // Request -> Dto
            var dto = mapper.Map<GroupDto>(request);
            await groupRepository.UpdateAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await groupRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

