using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Data.Repository.QuestionAnswer
{
    public interface IQuestionRepository
    {
        public Task<ApiResponse<Question>> SaveQuestionAsync(Question qADto);
        public Task<ApiResponse<List<Question>>> GetQuestionsAsync();
    }
}
