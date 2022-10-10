using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Data.Repository.Answers
{
    public interface IAnswerRepository
    {
        public Task<Guid> GetCorrectAnswer(Guid Questionguid);
        public Task<Guid> GetResultId(Guid UserId);
        public Task<int> GetAllAnswersNumber();
        public Task<ApiResponse<Result>> SaveAnswerAsync(ResultAnswer resultAnswer);
        public Task<ApiResponse<Result>> SaveResult(Guid ResultId);
        public Task<ApiResponse<Result>> GetResultAsync(GetResult getResult);
    }
}
