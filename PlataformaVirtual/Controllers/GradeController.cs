using Application.Grades.Dtos;
using Application.Grades.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlataformaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetGrades()
        {
            var grades = await _gradeService.GetAllDto();
            return Ok(grades);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GradeDto>> GetGrade(int id)
        {
            var grade = await _gradeService.GetByIdSaveDto(id);

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<ActionResult<GradeDto>> CreateGrade(SaveGradeDto gradeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdGrade = await _gradeService.Add(gradeDto);
            return CreatedAtAction(nameof(GetGrade), new { id = createdGrade.Id }, createdGrade);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<IActionResult> UpdateGrade(int id, SaveGradeDto gradeDto)
        {
            if (id != gradeDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _gradeService.Update(gradeDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRole.Teacher))]
        public async Task<ActionResult> DeleteGrade(int id)
        {
            await _gradeService.Delete(id);
            return NoContent();
        }
    }
}
