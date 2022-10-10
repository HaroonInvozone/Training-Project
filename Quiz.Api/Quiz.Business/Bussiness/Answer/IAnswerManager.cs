using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.Answers
{
    public interface IAnswerManager
    {
        public Task<ApiResponse<Result>> SaveAnswerAsync(GetAnswer getAnswer);
        public Task<ApiResponse<Result>> GetResultAsync(GetResult getResult);
    }
}
