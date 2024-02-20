namespace Domain.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public DateTime DueDate { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
