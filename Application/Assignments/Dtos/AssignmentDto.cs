using Domain.Entities;

namespace Application.Assignments.Dtos
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public DateTime DueDate { get; set; }
        public int SubjectId { get; set; }
    }
}
