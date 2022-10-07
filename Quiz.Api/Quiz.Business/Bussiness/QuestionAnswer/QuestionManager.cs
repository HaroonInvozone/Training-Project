﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quiz.Data.Repository.QuestionAnswer;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using System.Net;

namespace Quiz.Business.Bussiness.QuestionAnswer
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IConfiguration _configuration;
        private readonly IQuestionRepository _qARepository;
        private static Guid ResultId;
        private static int Count;
        //int static Count;
        public QuestionManager(IConfiguration configuration,IQuestionRepository qARepository)
        {
            _configuration = configuration; 
            _qARepository = qARepository;   
        }
        public async Task<ApiResponse<Question>> SaveQuestionAsync(Question question)
        {
            try
            {
                var apiResponse = new ApiResponse<Question>();
                if ((question.Title is not null) && (question.Answers is not null))
                {
                    var result = await _qARepository.SaveQuestionAsync(question);
                    apiResponse.Content = result.Content;
                }
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<List<Question>>> GetQuestionsAsync()
        {
            try
            {
                var apiResponce = new ApiResponse<List<Question>>();
                var result = await _qARepository.GetQuestionsAsync();
                apiResponce.Content = result.Content;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> SaveAnswerAsync(GetAnswer getAnswer) 
        {
            var resultAnswer = new ResultAnswer();
            var CorrectId = await _qARepository.GetCorrectAnswer(getAnswer.QuestionId);
            if (Count.Equals(1)) 
            {
                ResultId = await _qARepository.GetResultId(getAnswer.UserId);
                Count++;
            }
            resultAnswer.QuestionId = getAnswer.QuestionId;
            resultAnswer.AnswerId = getAnswer.AnswerId;
            resultAnswer.ResultId = ResultId;
            if (getAnswer.AnswerId.Equals(CorrectId))
                resultAnswer.IsCorrect = true;
            else
                resultAnswer.IsCorrect = false;
            await _qARepository.SaveAnswerAsync(resultAnswer);
            return null;
        }
    }
}
