namespace InvoPassport.Models.Models
{
    public class ResultAnswer
    {
        public Guid Id { get; set; }
        public Guid? QuestionId { get; set; }
        public Question? Question { get; set; }
        public Guid? AnswerId { get; set; }
        public Answer? Answer { get; set; }
        public Guid? ResultId { get; set; }
        public Result? Result { get; set; }
    }
}
