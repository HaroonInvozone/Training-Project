﻿using Microsoft.AspNetCore.Mvc;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.QuestionAnswer
{
    public interface IQuestionManager
    {
        public Task<ApiResponse<Question>> SaveQuestionAsync(Question qADto);
        public Task<ApiResponse<List<Question>>> GetQuestionsAsync();
    }
}