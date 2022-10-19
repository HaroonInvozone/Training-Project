using InvoPassport.Model.Models;
using InvoPassport.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoPassport.Data.Repository.Answers
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly InvoPassportAppContext _context;
        public AnswerRepository(InvoPassportAppContext context)
        {
            _context = context; 
        }
        public async Task<Guid> GetCorrectAnswer(Guid Questionguid)
        {
            try
            {
                var CorrectId = await _context.Answers.Where(x => x.QuestionId == Questionguid && x.IsCorrect == true).FirstOrDefaultAsync();
                return CorrectId.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> GetAllAnswersNumber() 
        {
            try
            {
                int? numbers = _context.Questions.Max(p => p.Number);
                return numbers;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public async Task<Guid> GetResultId(Guid UserId)
        {
            try
            {
                var Result = new Result();
                Result.Test_Date = DateTime.Now;
                Result.StartTime = DateTime.Now;
                Result.UserId = UserId;
                await _context.Results.AddAsync(Result);
                await _context.SaveChangesAsync();
                return Result.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<ApiResponse<Result>> SaveAnswerAsync(ResultAnswer resultAnswer)
        {
            try
            {
                var apiResponse = new ApiResponse<Result>();
                await _context.ResultAnswers.AddAsync(resultAnswer);
                await _context.SaveChangesAsync();
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result> SaveResult(SaveResult saveResult) 
        {
            try
            {
                var result = new Result();
                Random r = new Random();
                result = await _context.Results.FindAsync(saveResult.ResultId);
                result.CorrectAnswer = saveResult?.CorrectAnswers; ;
                result.TotalQuestion = await GetAllAnswersNumber();
                result.EndTime = DateTime.Now;
                if (saveResult?.CorrectAnswers > saveResult?.WrongAnswers) 
                {
                    result.CurrentState = true;
                    var user = await _context.Users.FindAsync(saveResult.UserId);
                    user.PassId = r.Next(1,14);
                    user.PassportExpiry = DateTime.Now.AddDays(2);
                    _context.Users.Update(user);
                }
                else
                    result.CurrentState = false;
                _context.Results.Update(result);
                await _context.SaveChangesAsync();
                return new Result 
                {
                    CorrectAnswer = result.CorrectAnswer,
                    TotalQuestion = result.TotalQuestion,
                    CurrentState = result.CurrentState,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
