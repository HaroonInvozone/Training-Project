using Microsoft.EntityFrameworkCore;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using QuizModels.Models;

namespace Quiz.Data.Repository.Answers
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizAppContext _context;
        public AnswerRepository(QuizAppContext context)
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
        public async Task<int> GetAllAnswersNumber() 
        {
            try
            {
                int numbers = _context.Questions.Max(p => p.Number);
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
        public async Task<ApiResponse<Result>> SaveResult(Guid ResultId) 
        {
            try
            {
                var apiResponse = new ApiResponse<Result>();
                var result = new Result();
                var TotalAnswers = await _context.ResultAnswers
                                    .Where(x => x.ResultId == ResultId)
                                    .Select(x => new
                                    {
                                        x.IsCorrect,
                                    })
                                    .ToListAsync();
                int CorrectAnswers = TotalAnswers
                                    .Where(x => x.IsCorrect == true)
                                    .Count();
                int WrongAnswers = TotalAnswers
                                    .Where(x => x.IsCorrect == false)
                                    .Count();
                result = await _context.Results.FindAsync(ResultId);
                result.CorrectAnswers = CorrectAnswers;
                result.TotalQuestions = TotalAnswers.Count();
                result.EndTime = DateTime.Now;
                if (CorrectAnswers > WrongAnswers)
                    result.CurrentState = true;
                else
                    result.CurrentState = false;
                _context.Results.Update(result);
                await _context.SaveChangesAsync();
                apiResponse.Content = result;
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
