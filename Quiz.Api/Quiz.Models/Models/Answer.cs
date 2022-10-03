using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Question question { get; set; }
    }
}
