using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Models.DTOs
{
    public class UserResult
    {
        public Users? users { get; set; }
        public Result? result { get; set; }
        public List<Question?> questionList { get; set; }
    }
}
