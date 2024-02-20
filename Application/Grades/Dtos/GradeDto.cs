using Domain.Entities;

namespace Application.Grades.Dtos
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public float Score { get; set; }
    }
}
