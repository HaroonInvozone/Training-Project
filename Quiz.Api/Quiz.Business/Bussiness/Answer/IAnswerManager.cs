using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;

namespace Quiz.Business.Bussiness.Answers
{
    public interface IAnswerManager
    {
        public Task<string> SaveAnswerAsync(GetAnswer getAnswer);

    }
}
