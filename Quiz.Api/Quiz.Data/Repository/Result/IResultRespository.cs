
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Data.Repository.Results
{
    public interface IResultRespository
    {
        public Task<ApiResponse<Result>> GetResultAsync(GetResult getResult);
    }
}
