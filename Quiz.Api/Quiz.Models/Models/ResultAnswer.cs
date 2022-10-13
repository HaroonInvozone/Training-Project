namespace Quiz.Models.Models
{
    public class ResultAnswer
    {
        public Guid Id { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        public Guid? ResultId { get; set; }
        public bool? IsCorrect { get; set; }
        public Result? Result { get; set; }
    }
}
