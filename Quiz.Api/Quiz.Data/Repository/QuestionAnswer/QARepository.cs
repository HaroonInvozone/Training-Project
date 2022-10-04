using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using QuizModels.Models;

namespace Quiz.Data.Repository.QuestionAnswer
{
    public class QARepository : IQARepository
    {
        private readonly QuizAppContext _context;
        public QARepository(QuizAppContext context)
        {
            _context = context; 
        }
        public async Task<IActionResult> SaveQuestionAnswers(QADto qADto)
        {
            return null;
        }
    }
}
