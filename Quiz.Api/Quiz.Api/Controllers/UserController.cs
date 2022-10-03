using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using QuizApp.Business.Bussiness.User;
using QuizApp.Model.DTOs;
using QuizApp.Model.Models;
using System.Net;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserManager _usermanager;
        private const string timeOut = "Logout Please";
        public UserController(IUserManager userManager)
        {
            _usermanager = userManager;
        }
        [HttpPost, Route("Register")]
        public async Task<ActionResult<ApiResponse<Users>>> RegisterUser(UserDto user) 
        {
            try
            {
                var apiResponse = new ApiResponse<Users>();

                if (user is null) {
                    {
                        apiResponse.Message = "Please fill out all fields";
                        apiResponse.Status = HttpStatusCode.BadRequest;
                    };
                    return Ok(apiResponse);
                }
                else {
                    var result = await _usermanager.CreateUser(user);
                    {
                        apiResponse.Message = "Success";
                        apiResponse.Content = result.Content;
                        apiResponse.Status = HttpStatusCode.OK;
                    };
                    return Ok(apiResponse);
                }
                
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }
        [HttpPost, Route("Login")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Login(UserDto user) 
        {
            var result = await _usermanager.Login(user);
            if (result.Content is not null)
            {
                var apiResponse = new ApiResponse<AuthResponse>()
                {
                    Message = "Success",
                    Content = result.Content,
                    Status = HttpStatusCode.OK
                };
                return Ok(apiResponse);
            }
            else {
                var apiResponse = new ApiResponse<AuthResponse>()
                {
                    Message = "Error",
                    Content = result.Content,
                    Status = HttpStatusCode.BadRequest
                };
                return Ok(apiResponse);
            }
        }
        [HttpGet, Route("Test")]
        public async Task<ActionResult<string>> Test()
        {
            return Ok("Hy test");
        }
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Refresh(TokenApiModel tokenApiModel)
        {
            var apiResponse = new ApiResponse<AuthResponse>();
            if (tokenApiModel is null)
            {
                {
                    apiResponse.Message = "Invalid client request";
                    apiResponse.Status = HttpStatusCode.BadRequest;
                };
                return BadRequest(apiResponse);
            }
            else 
            {
                var newToken = await _usermanager.GenerateTokenThroughVerification(tokenApiModel.RefreshToken);
                if(newToken.Message != timeOut)
                {
                    apiResponse.Message = "Your new token is here";
                    apiResponse.Content = newToken.Content;
                    apiResponse.Status = HttpStatusCode.BadRequest;
                }
                else 
                {
                    apiResponse.Message = "Redirect to login please";
                    apiResponse.Status = HttpStatusCode.BadRequest;
                }
                return Ok(apiResponse);
            }
        }
    }
}
