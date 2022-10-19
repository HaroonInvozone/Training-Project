using InvoPassport.Data.Repository.Results;
using InvoPassport.Models;
using InvoPassport.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Quiz.Data.Repository.Results
{
    public class ResultRespository : IResultRespository
    {
        private readonly InvoPassportAppContext _context;
        public ResultRespository(InvoPassportAppContext context)
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
                var query = (from x in this._context.Results?
                                .Include(x => x.User)
                                .Include(x => x.ResultAnswer)
                                .ThenInclude(x => x.Question)
                                .ThenInclude(x => x.Answers)
                                select x
                             );
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
