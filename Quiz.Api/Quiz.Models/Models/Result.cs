using QuizApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models.Models
{
    public  class Result
    {
        public Guid Id { get; set; }
        public DateTime Test_Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public bool CurrentState { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; }
        public List<ResultAnswer> ResultAnswer { get; set; }
    }
}
