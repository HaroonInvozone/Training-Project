
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Data.Repository.Results
{
    public interface IResultRespository
    {
        public Task<Result?> GetResultByIdAsync(Guid resultId);
        public Task<List<Result>> GetAllResult();
        public Task<List<Result?>> GetCompleteResultByIdAsync();
    }
}
