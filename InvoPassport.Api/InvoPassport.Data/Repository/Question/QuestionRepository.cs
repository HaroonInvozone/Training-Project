using InvoPassport.Model.Models;
using InvoPassport.Models;
using InvoPassport.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoPassport.Data.Repository.QuestionAnswer
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly InvoPassportAppContext _context;
        public QuestionRepository(InvoPassportAppContext context)
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
        public async Task<Question?> GetQuestionByIdAsync(Guid questionId) 
        {
            try 
            {
                var question = new Question();
                question = await _context.Questions.Include(x => x.Answers).Where(x => x.Id == questionId).FirstOrDefaultAsync();
                return question;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            try
            {
                //under development
                _context.Questions.Update(question);
                _context.Answers.UpdateRange(question.Answers);
                await _context.SaveChangesAsync();
                return question;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
