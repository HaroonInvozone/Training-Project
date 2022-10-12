using Microsoft.EntityFrameworkCore;
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
    }
}
