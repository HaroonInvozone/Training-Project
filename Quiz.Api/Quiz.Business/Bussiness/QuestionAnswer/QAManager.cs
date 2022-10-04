using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quiz.Data.Repository.QuestionAnswer;
using Quiz.Models.DTOs;
using QuizApp.Model.Models;

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
        public async Task<IActionResult> SaveQuestionAnswers(QADto qADto) 
        {

            return null;
        }
    }
}
