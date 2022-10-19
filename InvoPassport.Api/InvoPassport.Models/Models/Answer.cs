namespace InvoPassport.Models.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string? Option { get; set; }
        public bool? IsCorrect { get; set; }
        public Guid? QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
