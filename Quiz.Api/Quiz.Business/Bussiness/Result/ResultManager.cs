using Quiz.Data.Repository.Results;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.Results
{
    public class ResultManager : IResultManager
    {
        private readonly IResultRespository _resultRespository;
        public ResultManager(IResultRespository resultRespository)
        {
            _resultRespository = resultRespository;
        }
        public async Task<ApiResponse<Result>> GetResultAsync(GetResult getResult)
        {
            try
            {
                var apiResponse = new ApiResponse<Result>();
                var result = await _resultRespository.GetResultAsync(getResult);
                apiResponse.Content = result.Content;
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
