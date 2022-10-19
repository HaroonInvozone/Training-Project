

using InvoPassport.Data.Repository.Answers;
using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;
using Microsoft.Extensions.Configuration;

namespace Quiz.Business.Bussiness.Answers
{
    public class AnswerManager : IAnswerManager
    {
        private readonly IConfiguration _configuration;
        private readonly IAnswerRepository _answerRepository;
        private static Guid ResultId;
        private static int? TotalQuestions;
        private static int? correct = 0;
        private static int? wrongAnswers = 0;
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
                    correct++;

                else
                    wrongAnswers++;
                var result = await _answerRepository.SaveAnswerAsync(resultAnswer);
                if (TotalQuestions == getAnswer.QuestionNumber)
                {
                    var saveResult = new SaveResult();
                    saveResult.ResultId = ResultId;
                    saveResult.CorrectAnswers = correct;
                    saveResult.WrongAnswers = wrongAnswers;
                    saveResult.UserId = getAnswer.UserId;
                    var response = await _answerRepository.SaveResult(saveResult);
                    ResultId = new Guid();
                    TotalQuestions = 0;
                    correct = 0;
                    wrongAnswers = 0;
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
