using System;
namespace InvoPassport.Models.DTOs
{
    public  class GetAnswer
    {
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
        public Guid UserId { get; set; }
        public int QuestionNumber { get; set; }
    }
}
