using Quiz.Models.Models;

namespace Quiz.Models.DTOs
{
    public class QADto
    {
        public string Question { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
