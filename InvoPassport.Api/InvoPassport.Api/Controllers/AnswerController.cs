using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.Answers;
using System.Net;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerManager _answerManager;
        public AnswerController(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }
        [HttpGet, Route("SaveQuestionResult")]
        public async Task<ApiResponse<Result>> SaveQuestionResultAsync([FromQuery] GetAnswer getAnswer)
        //public async Task<ApiResponse<Result>> SaveAnswerAsync()
        {
            try
            {
                //for testing purpose
                //var getAnswer = new GetAnswer();
                //getAnswer.UserId = new Guid("40DE4EC5-BD7B-DD89-9CF5-B08884BD4166");
                //getAnswer.QuestionId = new Guid("256231EF-C539-491B-C983-08DAAAB8FF08");
                //getAnswer.AnswerId = new Guid("08D155BA-39B1-47A7-98BA-08DAAAB8FF25");
                //getAnswer.QuestionNumber = 2;
                var apiResponse = new ApiResponse<Result>();
                if ((getAnswer.UserId == null || getAnswer.UserId == Guid.Empty) || (getAnswer.AnswerId == null || getAnswer.AnswerId == Guid.Empty) || (getAnswer.QuestionId == null || getAnswer.QuestionId == Guid.Empty))
                {
                    apiResponse.Message = "Please fill out all fields";
                    apiResponse.Status = HttpStatusCode.BadGateway;
                    return apiResponse;
                }
                var result = new Result();
                var response = await _answerManager.SaveAnswerAsync(getAnswer);
                if (response.Content is null)
                {
                    apiResponse.Message = "Your answer is save successssfully";
                    apiResponse.Status = HttpStatusCode.OK;
                }
                else
                {
                    apiResponse.Message = "Here is your result";
                    apiResponse.Status = HttpStatusCode.OK;
                    apiResponse.Content = response.Content;
                }
                return apiResponse;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
