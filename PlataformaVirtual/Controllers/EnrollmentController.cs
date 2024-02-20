using Application.Enrollments.Dtos;
using Application.Enrollments.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlataformaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetEnrollments()
        {
            var enrollments = await _enrollmentService.GetAllDto();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetByIdSaveDto(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<ActionResult<EnrollmentDto>> CreateEnrollment(SaveEnrollmentDto enrollmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEnrollment = await _enrollmentService.Add(enrollmentDto);
            return CreatedAtAction(nameof(GetEnrollment), new { id = createdEnrollment.Id }, createdEnrollment);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<IActionResult> UpdateEnrollment(int id, SaveEnrollmentDto enrollmentDto)
        {
            if (id != enrollmentDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _enrollmentService.Update(enrollmentDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<ActionResult> DeleteEnrollment(int id)
        {
            await _enrollmentService.Delete(id);
            return NoContent();
        }
    }
}
