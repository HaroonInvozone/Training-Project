using InvoPassport.Model.Models;
using InvoPassport.Models.Models;

namespace InvoPassport.Data.Repository.QuestionAnswer
{
    public interface IQuestionRepository
    {
        public Task<ApiResponse<Question>> SaveQuestionAsync(Question qADto);
        public Task<ApiResponse<List<Question>>> GetQuestionsAsync();
        public Task<Question?> GetQuestionByIdAsync(Guid questionId);
        public Task<Question> UpdateQuestionAsync(Question question);
    }
}
