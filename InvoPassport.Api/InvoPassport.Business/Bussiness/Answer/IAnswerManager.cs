using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;

namespace Quiz.Business.Bussiness.Answers
{
    public interface IAnswerManager
    {
        public Task<ApiResponse<Result>> SaveAnswerAsync(GetAnswer getAnswer);
    }
}
