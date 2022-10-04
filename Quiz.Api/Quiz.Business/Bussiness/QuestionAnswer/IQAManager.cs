using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.QuestionAnswer
{
    public interface IQAManager
    {
        public Task<IActionResult> SaveQuestionAnswers(QADto qADto);
    }
}
