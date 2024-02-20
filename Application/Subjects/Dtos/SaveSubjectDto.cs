using Domain.Entities;

namespace Application.Subjects.Dtos
{
    public class SaveSubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
    }
}
