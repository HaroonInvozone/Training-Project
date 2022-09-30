using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using QuizApp.Business.Bussiness.User;
using QuizApp.Model.DTOs;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserManager _usermanager;
        public UserController(IUserManager userManager)
        {
            _usermanager = userManager;
        }
        [HttpPost, Route("Register")]
        public async Task<IActionResult> RegisterUser(UserDto user) 
        {
            if (user is null)
                return Content("Please fillout all fields");
            var result = await _usermanager.CreateUser(user);
            return Ok(result);
        }
        [HttpPost, Route("Login")]
        public async Task<ActionResult<string>> Login(UserDto user) 
        {
            var result = await _usermanager.Login(user);
            return Ok(result);
        }
        [HttpGet, Route("Test"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> Test()
        {
            return Ok("Hy test");
        }
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");
            string newToken =  await _usermanager.GenerateTokenThroughVerification(tokenApiModel.RefreshToken);
            return Ok(newToken);
        }
            //[HttpGet, Route("GetRefreshToken")]
            //public string GetRefreshToken(UserDto? userDto) 
            //{
            //    var result =  _usermanager.GenerateRefreshToken(userDto);
            //    return Ok(result);
            //}
            //public async Task<ActionResult<ApiResponse>> Login(UserDto user)
            //{
            //    ApiResponse response = new ApiResponse();

            //    if (user is null)
            //    {
            //        response.message = "";

            //        return response; 
            //    }
            //    return response;
            //}
        }
}
