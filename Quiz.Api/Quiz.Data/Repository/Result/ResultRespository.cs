using Microsoft.EntityFrameworkCore;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using QuizModels.Models;

namespace Quiz.Data.Repository.Results
{
    public class ResultRespository : IResultRespository
    {
        private readonly QuizAppContext _context;
        public ResultRespository(QuizAppContext context)
        {
            _context = context; 
        }
        public async Task<ApiResponse<Result>> GetResultAsync(GetResult getResult) 
        {
            try 
            {
                var apiResponce = new ApiResponse<Result>();
                var result = new Result();
                result = await _context.Results.Where(x => x.UserId == getResult.UserId && x.Id == getResult.ResultId).FirstOrDefaultAsync();
                apiResponce.Content = result;
                return apiResponce;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

    }
    
}
