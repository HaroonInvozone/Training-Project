using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;

namespace Quiz.Business.Bussiness.Results
{
    public interface IResultManager
    {
        public Task<ApiResponse<UserResult>> GetResultAsync(Guid resultId);
        public Task<List<Result>> GetAllResult();
        public Task<List<Result?>> GetCompleteResultAsync();
    }
}
