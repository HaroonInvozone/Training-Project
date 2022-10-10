using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.Answers;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
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
        [HttpGet, Route("SaveAnswer")]
        public async Task<ApiResponse<Result>> SaveAnswerAsync([FromQuery] GetAnswer getAnswer)
        {
            try
            {
                var apiResponse = new ApiResponse<Result>();
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
        [HttpGet, Route("GetResult By Result Id")]
        public async Task<ApiResponse<Result>> GetResultByIdAsync(GetResult getResult) 
        {
            try
            {
                var apiResponce = new ApiResponse<Result>();
                var result = await _answerManager.GetResultAsync(getResult);
                apiResponce.Message = "Here is the result";
                apiResponce.Status = HttpStatusCode.OK;
                apiResponce.Content = result.Content;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet, Route("Test")]
        public async Task<ActionResult<string>> Test()
        {
            return Ok("Hy test");
        }
    }
}
