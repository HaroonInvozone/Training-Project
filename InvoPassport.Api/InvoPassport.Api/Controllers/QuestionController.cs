
using InvoPassport.Model.Models;
using InvoPassport.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.QuestionAnswer;
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
        public async Task<ActionResult<ApiResponse<Question>>> AddQuestionsAsync(Question question)
        {
            try
            {
                var apiResponse = new ApiResponse<Question>();
                if (question.Title is null || question.Answers is null)
                {
                    apiResponse.Message = "Please fill out all fields";
                    apiResponse.Status = HttpStatusCode.BadGateway;
                    return apiResponse;
                }
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
        [HttpGet, Route("GetQuestionById")]
        public async Task<ActionResult<ApiResponse<Question>>> GetQuestionByIdAsync(Guid questionId)
        {
            try
            {
                var apiResponce = new ApiResponse<Question>();
                if (questionId == null || questionId == Guid.Empty) 
                {
                    apiResponce.Message = "Please enter Question id";
                    apiResponce.Status = HttpStatusCode.BadRequest;
                    return BadRequest(apiResponce);
                }
                var result = await _questionmanager.GetQuestionByIdAsync(questionId);
                apiResponce.Message = "Question Details";
                apiResponce.Status = HttpStatusCode.OK;
                apiResponce.Content = result;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut, Route("UpateQuestions")]
        public async Task<ActionResult<ApiResponse<Question>>> UpdateQuestionsAsync(Question question)
        {
            try
            {
                var apiResponse = new ApiResponse<Question>();
                //if (question.Title is null || question.Answers is null)
                //{
                //    apiResponse.Message = "Please fill out all fields";
                //    apiResponse.Status = HttpStatusCode.BadGateway;
                //    return apiResponse;
                //}
                var result = await _questionmanager.UpdateQuestionAsync(question);
                if (result is not null)
                {
                    {
                        apiResponse.Message = "Question Update successfully";
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
    }
}
