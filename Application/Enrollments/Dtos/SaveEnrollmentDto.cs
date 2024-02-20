using Domain.Entities;

namespace Application.Enrollments.Dtos
{
    public class SaveEnrollmentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
