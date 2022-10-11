using Microsoft.Extensions.Configuration;
using Quiz.Data.Repository.Answers;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.Answers
{
    public class AnswerManager : IAnswerManager
    {
        private readonly IConfiguration _configuration;
        private readonly IAnswerRepository _answerRepository;
        private static Guid ResultId;
        private static int TotalQuestions;
        public AnswerManager(IConfiguration configuration, IAnswerRepository answerManager)
        {
            _configuration = configuration;
            _answerRepository = answerManager;
        }
        public async Task<ApiResponse<Result>> SaveAnswerAsync(GetAnswer getAnswer)
        {
            try
            {
                var apiResponce = new ApiResponse<Result>();
                var resultAnswer = new ResultAnswer();
                var CorrectId = await _answerRepository.GetCorrectAnswer(getAnswer.QuestionId);
                if (ResultId == null || ResultId == Guid.Empty)
                {
                    ResultId = await _answerRepository.GetResultId(getAnswer.UserId);
                    TotalQuestions = await _answerRepository.GetAllAnswersNumber();
                }
                resultAnswer.QuestionId = getAnswer.QuestionId;
                resultAnswer.AnswerId = getAnswer.AnswerId;
                resultAnswer.ResultId = ResultId;
                if (getAnswer.AnswerId.Equals(CorrectId))
                    resultAnswer.IsCorrect = true;
                else
                    resultAnswer.IsCorrect = false;
                //pass api response as it is 
                var result = await _answerRepository.SaveAnswerAsync(resultAnswer);
                if (TotalQuestions == getAnswer.QuestionNumber)
                {
                    var response = await _answerRepository.SaveResult(ResultId);
                    apiResponce.Content = response.Content;
                }
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
