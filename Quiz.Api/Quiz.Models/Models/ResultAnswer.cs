namespace Quiz.Models.Models
{
    public class ResultAnswer
    {
        public Guid Id { get; set; }
        public Guid Question_Id { get; set; }
        public Guid AnswerId { get; set; }
        public Guid Result_Id { get; set; }
        public Question Question { get; set; }
        public virtual Answer Answer { get; set; }
        public Result Result { get; set; }
    }
}
