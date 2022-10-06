using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models.DTOs
{
    public  class GetAnswer
    {
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }  
    }
}
