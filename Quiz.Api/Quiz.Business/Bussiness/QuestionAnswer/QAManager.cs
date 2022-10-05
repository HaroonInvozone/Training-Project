using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quiz.Data.Repository.QuestionAnswer;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using System.Net;

namespace Quiz.Business.Bussiness.QuestionAnswer
{
    public class QAManager : IQAManager
    {
        private readonly IConfiguration _configuration;
        private readonly IQARepository _qARepository;
        public QAManager(IConfiguration configuration,IQARepository qARepository)
        {
            _configuration = configuration; 
            _qARepository = qARepository;   
        }
        public async Task<ApiResponse<Question>> SaveQuestionAsync(Question question)
        {
            var apiResponse = new ApiResponse<Question>();  
            if ((question.Title is not null) && (question.Answers is not null))
            {
                var result = await _qARepository.SaveQuestionAsync(question);
                apiResponse.Content = result.Content;   
            }
            return apiResponse;
        }
    }
}
