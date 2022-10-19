
using InvoPassport.Data.Repository.QuestionAnswer;
using InvoPassport.Model.Models;
using InvoPassport.Models.Models;
using Microsoft.Extensions.Configuration;

namespace Quiz.Business.Bussiness.QuestionAnswer
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IConfiguration _configuration;
        private readonly IQuestionRepository _qARepository;
        public QuestionManager(IConfiguration configuration,IQuestionRepository qARepository)
        {
            _configuration = configuration; 
            _qARepository = qARepository;   
        }
        public async Task<ApiResponse<Question>> SaveQuestionAsync(Question question)
        {
            try
            {
                var apiResponse = new ApiResponse<Question>();
                if ((question.Title is not null) && (question.Answers is not null))
                {
                    var result = await _qARepository.SaveQuestionAsync(question);
                    apiResponse.Content = result.Content;
                }
                return apiResponse;
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
                var apiResponce = new ApiResponse<List<Question>>();
                var result = await _qARepository.GetQuestionsAsync();
                apiResponce.Content = result.Content;
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
                return await _qARepository.GetQuestionByIdAsync(questionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
}
        public async Task<ApiResponse<Question>?> UpdateQuestionAsync(Question question)
        {
            try
            {
                var apiResponce = new ApiResponse<Question?>();
                var Question = new Question();
                Question = await _qARepository.UpdateQuestionAsync(question);
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
