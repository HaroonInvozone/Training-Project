using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.QuestionAnswer
{
    public interface IQAManager
    {
        public Task<ApiResponse<Question>> SaveQuestionAsync(Question qADto);
    }
}
