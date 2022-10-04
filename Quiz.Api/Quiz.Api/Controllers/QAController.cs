using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Business.Bussiness.QuestionAnswer;
using Quiz.Models.DTOs;
using QuizApp.Business.Bussiness.User;

namespace Quiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QAController : ControllerBase
    {
        private readonly IQAManager _usermanager;
        public QAController(IQAManager userManager)
        {
            _usermanager = userManager;
        }
        [HttpPost, Route("AddQuestions")]
        public async Task<ActionResult> AddQuestions(QADto jsonContent)
        {
            await _usermanager.SaveQuestionAnswers(jsonContent);
            return Ok();
        }
    }
}
