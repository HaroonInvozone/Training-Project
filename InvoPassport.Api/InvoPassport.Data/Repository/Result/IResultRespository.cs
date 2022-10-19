using InvoPassport.Models.Models;

namespace InvoPassport.Data.Repository.Results
{
    public interface IResultRespository
    {
        public Task<Result?> GetResultByIdAsync(Guid resultId);
        public Task<List<Result>> GetAllResult();
        public Task<List<Result?>> GetCompleteResultByIdAsync();
    }
}
