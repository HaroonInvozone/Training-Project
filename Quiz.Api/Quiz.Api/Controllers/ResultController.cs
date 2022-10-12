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
                var apiResponse = new ApiResponse<Result>();
                if ((getResult.UserId == null || getResult.UserId == Guid.Empty) || (getResult.ResultId == null || getResult.ResultId == Guid.Empty))
                {
                    apiResponse.Message = "Please fill out all fields";
                    apiResponse.Status = HttpStatusCode.BadGateway;
                    return apiResponse;
                }
                var result = await _resultManager.GetResultAsync(getResult);
                apiResponse.Message = "Here is the result";
                apiResponse.Status = HttpStatusCode.OK;
                apiResponse.Content = result.Content;
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
