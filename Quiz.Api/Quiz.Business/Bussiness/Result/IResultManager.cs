using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.Results
{
    public interface IResultManager
    {
        public Task<ApiResponse<UserResult>> GetResultAsync(Guid resultId);
        public Task<List<Result>> GetAllResult();
        public Task<List<Result?>> GetCompleteResultAsync();
    }
}
