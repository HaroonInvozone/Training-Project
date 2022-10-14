using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.Results
{
    public interface IResultManager
    {
        public Task<ApiResponse<UserResult>> GetResultAsync(GetResult getResult);
        public Task<Result> GetResultById(Guid resultId);
    }
}
