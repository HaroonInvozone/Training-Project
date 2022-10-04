using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;

namespace Quiz.Data.Repository.QuestionAnswer
{
    public interface IQARepository
    {
        public Task<IActionResult> SaveQuestionAnswers(QADto qADto);
    }
}
