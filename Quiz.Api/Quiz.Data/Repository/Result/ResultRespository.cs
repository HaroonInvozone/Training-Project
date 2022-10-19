using Microsoft.EntityFrameworkCore;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using QuizModels.Models;
using System.Security.Cryptography;

namespace Quiz.Data.Repository.Results
{
    public class ResultRespository : IResultRespository
    {
        private readonly QuizAppContext _context;
        public ResultRespository(QuizAppContext context)
        {
            _context = context;
        }

        public async Task<Result?> GetResultByIdAsync(Guid resultId)
        {
            try
            {
                return await _context.Results.Include(x => x.ResultAnswer).Include(x => x.User).Where(x => x.Id == resultId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Result>> GetAllResult()
        {
            try
            {
                return await _context.Results.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Result?>> GetCompleteResultByIdAsync()
        {
            try
            {
                //var result - new Result();
                var query = (from x in this._context.Results?
                             .Include(x => x.User)
                             .Include(x => x.ResultAnswer)
                             .ThenInclude(x => x.Question)
                             .ThenInclude(x => x.Answers)
                             select x);
                var result = await query.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
