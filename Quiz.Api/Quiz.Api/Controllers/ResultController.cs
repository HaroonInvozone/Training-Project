using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.Results;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using System.Net;

namespace Quiz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController
    {
        private readonly IResultManager _resultManager;
        public ResultController(IResultManager resultManager)
        {
            _resultManager = resultManager;
        }
        [HttpGet, Route("GetResultById"), Authorize(Roles = "Admin")]
        public async Task<ApiResponse<Result>> GetResultByIdAsync(GetResult getResult)
        {
            try
            {
                var apiResponce = new ApiResponse<Result>();
                var result = await _resultManager.GetResultAsync(getResult);
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
    }
}
