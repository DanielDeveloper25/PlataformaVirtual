using Application.Assignments.Dtos;
using Application.Assignments.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlataformaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments()
        {
            var assignments = await _assignmentService.GetAllDto();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {
            var assignment = await _assignmentService.GetByIdSaveDto(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<ActionResult<AssignmentDto>> CreateAssignment(SaveAssignmentDto assignmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAssignment = await _assignmentService.Add(assignmentDto);
            return CreatedAtAction(nameof(GetAssignment), new { id = createdAssignment.Id }, createdAssignment);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<IActionResult> UpdateAssignment(int id, SaveAssignmentDto assignmentDto)
        {
            if (id != assignmentDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _assignmentService.Update(assignmentDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            await _assignmentService.Delete(id);
            return NoContent();
        }
    }
}
