using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using QuizModels.Models;

namespace Quiz.Data.Repository.QuestionAnswer
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizAppContext _context;
        public QuestionRepository(QuizAppContext context)
        {
            _context = context; 
        }
        public async Task<ApiResponse<Question>> SaveQuestionAsync(Question question)
        {
            try
            {
                var apiresponse = new ApiResponse<Question>();
                await _context.Questions.AddAsync(question);
                await _context.Answers.AddRangeAsync(question.Answers);
                await _context.SaveChangesAsync();
                apiresponse.Content = question;
                return apiresponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<List<Question>>> GetQuestionsAsync()
        {
            try
            {
                var question = new List<Question>();
                var apiResponce = new ApiResponse<List<Question>>();
                var answers = new Answer();
                question = await _context.Questions.Include(x => x.Answers).ToListAsync();
                apiResponce.Content = question;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> SaveAnswerAsync(ResultAnswer resultAnswer) 
        {
            await _context.ResultAnswers.AddAsync(resultAnswer);
            await _context.SaveChangesAsync();
            return null;
        }
        public async Task<Guid> GetCorrectAnswer(Guid Questionguid) 
        {
            var CorrectId = await _context.Answers.Where(x => x.QuestionId == Questionguid && x.IsCorrect == true).FirstOrDefaultAsync();
            return CorrectId.Id;
        }
        public async Task<Guid> GetResultId(Guid UserId) 
        {
            try
            {
                var Result = new Result();
                Result.Test_Date = DateTime.Now;
                Result.StartTime = DateTime.Now;
                await _context.Results.AddAsync(Result);
                await _context.SaveChangesAsync();
                return Result.Id;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
             
        }
    }
}
