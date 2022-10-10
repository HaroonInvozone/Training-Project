using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using Quiz.Models.Models;

namespace Quiz.Business.Bussiness.Answers
{
    public interface IAnswerManager
    {
        public Task<string> SaveAnswerAsync(GetAnswer getAnswer);
        public Task<Result> GetResultAsync(GetResult getResult);
    }
}
