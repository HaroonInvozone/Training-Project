using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.Answers;
using Quiz.Models.DTOs;
using Quiz.Models.Models;

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
        public async Task<string> SaveAnswerAsync([FromQuery] GetAnswer getAnswer)
        {
            var result = await _answerManager.SaveAnswerAsync(getAnswer);
            return result;
        }
        [HttpGet, Route("GetResult By Result Id")]
        public async Task<Result> GetResult(GetResult getResult) 
        {
            var result = await _answerManager.GetResultAsync(getResult);
            return result;
        }
        [HttpGet, Route("Test")]
        public async Task<ActionResult<string>> Test()
        {
            return Ok("Hy test");
        }
    }
}
