namespace InvoPassport.Models.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string? Title { get; set; }
        public List<Answer>? Answers { get; set; }
    }
}
