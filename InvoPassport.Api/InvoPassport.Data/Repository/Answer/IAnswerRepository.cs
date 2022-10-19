
using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;

namespace InvoPassport.Data.Repository.Answers
{
    public interface IAnswerRepository
    {
        public Task<Guid> GetCorrectAnswer(Guid Questionguid);
        public Task<Guid> GetResultId(Guid UserId);
        public Task<int?> GetAllAnswersNumber();
        public Task<ApiResponse<Result>> SaveAnswerAsync(ResultAnswer resultAnswer);
        public Task<Result> SaveResult(SaveResult saveResult);
        
    }
}
