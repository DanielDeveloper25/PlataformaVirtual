namespace Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
