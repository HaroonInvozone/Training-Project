

using InvoPassport.Model.Models;
using InvoPassport.Models.Models;

namespace InvoPassport.Models.DTOs
{
    public  class UserResult
    {
        public Users? users { get; set; }
        public Result? result { get; set; }
        public List<UserAttempt?> UserAttempt { get; set; }
    }
    public class SaveResult 
    {
        public Guid ResultId { get; set; }
        public Guid UserId { get; set; }
        public int? CorrectAnswers { get; set; }
        public int? WrongAnswers { get; set; }
    }
    public class UserAttempt
    {
        public string  Title { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
