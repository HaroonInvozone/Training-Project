using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.QuestionAnswer;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Business.Bussiness.User;
using QuizApp.Model.Models;
using System.Net;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionManager _questionmanager;
        public QuestionController(IQuestionManager userManager)
        {
            _questionmanager = userManager;
        }
        [HttpGet, Route("AddQuestions")]
        public async Task<ActionResult<ApiResponse<Question>>> AddQuestions(Question question)
        {
            try
            {
                var apiResponse = new ApiResponse<Question>();
                var result = await _questionmanager.SaveQuestionAsync(question);
                if (result is not null)
                {
                    {
                        apiResponse.Message = "Question save successfully";
                        apiResponse.Status = HttpStatusCode.OK;
                        apiResponse.Content = result.Content;
                    };
                    return Ok(apiResponse);
                }
                else
                {
                    apiResponse.Message = "Please fill out all fields";
                    apiResponse.Status = HttpStatusCode.BadRequest;
                    return BadRequest(apiResponse);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet, Route("GetAllQuestion")]
        public async Task<ApiResponse<List<Question>>> GetQuestionAsync() 
        {
            try
            {
                var apiResponce = new ApiResponse<List<Question>>();
                var result = await _questionmanager.GetQuestionsAsync();
                apiResponce.Message = "List of questions";
                apiResponce.Status = HttpStatusCode.OK;
                apiResponce.Content = result.Content;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
