using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.Results
{
    public interface IResultManager
    {
        public Task<ApiResponse<Result>> GetResultAsync(GetResult getResult);
    }
}
