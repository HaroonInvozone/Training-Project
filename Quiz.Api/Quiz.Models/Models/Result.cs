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
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public int Correct_Answers { get; set; }
        public int Total_Questions { get; set; }
        public bool Current_State { get; set; }
        public Guid UserId { get; set; }
        public Users User { get; set; }
        public ICollection<ResultAnswer> ResultAnswer { get; set; }
    }
}
