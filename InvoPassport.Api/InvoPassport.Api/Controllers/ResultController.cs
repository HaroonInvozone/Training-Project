
using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.Results;
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
        [HttpGet, Route("GetResultsDetailList")]
        public async Task<ApiResponse<List<Result>>> GetResultsDetailList()
        {
            try
            {
                var apiResponse = new ApiResponse<List<Result>>();
                apiResponse.Message = "Here is the list";
                apiResponse.Status = HttpStatusCode.OK;
                apiResponse.Content = await _resultManager.GetCompleteResultAsync();
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //This api is used to only get the result twble record without Incude any other entity record
        //[HttpGet, Route("GetResultsList")]
        //public async Task<ApiResponse<List<Result>>> GetResultsList()
        //{
        //    try
        //    {
        //        var apiResponse = new ApiResponse<List<Result>>();
        //        apiResponse.Message = "Here is the list";
        //        apiResponse.Status = HttpStatusCode.OK;
        //        apiResponse.Content = await _resultManager.GetAllResult();
        //        return apiResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        ////This api is used to get result by id
        //[HttpGet, Route("GetResultById")]
        //public async Task<ApiResponse<UserResult>> GetResultByUserIdAsync([FromQuery] Guid resultId)
        //{
        //    try
        //    {
        //        var apiResponse = new ApiResponse<UserResult>();
        //        if ((resultId == null || resultId == Guid.Empty))
        //        {
        //            apiResponse.Message = "Please enter Result Id";
        //            apiResponse.Status = HttpStatusCode.BadGateway;
        //            return apiResponse;
        //        }
        //        var result = await _resultManager.GetResultAsync(resultId);
        //        apiResponse.Message = "Here is the result";
        //        apiResponse.Status = HttpStatusCode.OK;
        //        apiResponse.Content = result.Content;
        //        return apiResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}


