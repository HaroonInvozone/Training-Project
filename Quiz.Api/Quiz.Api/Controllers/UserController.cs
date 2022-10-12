using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
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
        [HttpGet, Route("GetAllUsers"), Authorize(Roles = "Admin")]
        public async Task<ApiResponse<List<Users>>> GetUserAsync()
        {
            try {
                var apiResponce = new ApiResponse<List<Users>>();
                var result = await _usermanager.GetUsersAsync();
                apiResponce.Message = "List of Users";
                apiResponce.Status = HttpStatusCode.OK;
                apiResponce.Content = result.Content;
                return apiResponce;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        [HttpPost, Route("Register")]
        public async Task<ActionResult<ApiResponse<Users>>> RegisterUser(UserDto user) 
        {
            try
            {
                var apiResponse = new ApiResponse<Users>();

                if (user.UserName is null || user.Email is null || user.Password is null) 
                {
                    {
                        apiResponse.Message = "Please fill out all fields";
                        apiResponse.Status = HttpStatusCode.NotAcceptable;
                    };
                    return Ok(apiResponse);
                }
                else
                {
                    var result = await _usermanager.CreateUser(user);
                    {
                        apiResponse.Message = "Success";
                        apiResponse.Content = result.Content;
                        apiResponse.Status = HttpStatusCode.OK;
                    };
                    return Ok(apiResponse);
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        [HttpPost, Route("Login")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Login(UserDto user) 
        {
            try 
            {
                var apiResponse = new ApiResponse<AuthResponse>();
                if (user.UserName is null || user.Password is null) 
                {
                    apiResponse.Message = "Please fill out all fields";
                    apiResponse.Status = HttpStatusCode.BadGateway;
                }
                var result = await _usermanager.Login(user);
                if (result.Content is not null)
                {
                    
                    {
                        apiResponse.Message = "Success";
                        apiResponse.Content = result.Content;
                        apiResponse.Status = HttpStatusCode.OK;
                    };
                    return Ok(apiResponse);
                }
                else
                {
                    {
                        apiResponse.Message = "Invalid User...";
                        apiResponse.Content = result.Content;
                        apiResponse.Status = HttpStatusCode.NotFound;
                    };
                    return BadRequest(apiResponse);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Refresh(TokenApiModel tokenApiModel)
        {
            try 
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
                    if (newToken.Message != timeOut)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete, Route("Logout")]
        public async Task<ApiResponse<string>> LogoutAsync(TokenApiModel tokenApiModel)
        { 
            var apiResponse = new ApiResponse<string>();
            var result = await _usermanager.LogoutAsync(tokenApiModel);
            apiResponse.Message = result.Message;
            apiResponse.Status = HttpStatusCode.OK;
            return apiResponse;
        }
    }
}
