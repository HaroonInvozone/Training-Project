using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.Answers;
using Quiz.Models.DTOs;

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
        [HttpGet, Route("Test")]
        public async Task<ActionResult<string>> Test()
        {
            return Ok("Hy test");
        }
    }
}
