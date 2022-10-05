using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using QuizModels.Models;

namespace Quiz.Data.Repository.QuestionAnswer
{
    public class QARepository : IQARepository
    {
        private readonly QuizAppContext _context;
        public QARepository(QuizAppContext context)
        {
            _context = context; 
        }
        public async Task<ApiResponse<Question>> SaveQuestionAsync(Question question)
        {
            var apiresponse = new ApiResponse<Question>();
            await _context.Questions.AddAsync(question);
            await _context.Answers.AddRangeAsync(question.Answers);
            await _context.SaveChangesAsync();
            apiresponse.Content = question;
            return apiresponse;
        }
    }
}
