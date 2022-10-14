using Microsoft.AspNetCore.Http;
using Quiz.Data.Repository.QuestionAnswer;
using Quiz.Data.Repository.Results;
using Quiz.Models.DTOs;
using Quiz.Models.Models;
using QuizApp.Data.Repository.User;
using QuizApp.Model.Models;

namespace Quiz.Business.Bussiness.Results
{
    public class ResultManager : IResultManager
    {
        private readonly IResultRespository _resultRespository;
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;
        public ResultManager(IResultRespository resultRespository, IUserRepository userRepository, IQuestionRepository questionRepository)
        {
            _resultRespository = resultRespository;
            _userRepository = userRepository;   
            _questionRepository = questionRepository;
        }
        public async Task<ApiResponse<UserResult>> GetResultAsync(GetResult getResult)
        {
            try
            {
                var apiResponse = new ApiResponse<UserResult>();
                var userResult = new UserResult();
                var QuestionsList = new List<Question?>();
                var QuestionsList2 = new List<Question?>();
                var Questions1= new Question();
                
                var ansList = new List<Answer?>();
                var userProfile = await _userRepository.GetUsersByIdAsync(getResult.UserId);
                var resultuser = await _resultRespository.GetResultByIdAsync(getResult.ResultId);
                foreach (var answer in resultuser.ResultAnswer)
                {
                    var question = await _questionRepository.GetQuestionByIdAsync((Guid)answer.QuestionId);
                    //Questions1.Id = question.Id;
                    //Questions1.Title = question.Title;
                    //QuestionsList2.Add(Questions1);
                    //foreach (var answers in question.Answers)
                    //{
                    //    var ANS = new Answer();
                    //    if (answers.Id == answer.AnswerId)
                    //    {
                    //        ANS.IsCorrect = true;
                    //        ANS.Id = answers.Id;
                    //        ANS.Option = answers.Option;
                    //        ANS.Question = answers.Question;
                    //        ANS.QuestionId = answers.QuestionId;
                    //    }
                    //    else
                    //    {
                    //        ANS.IsCorrect = false;
                    //        ANS.Id = answers.Id;
                    //        ANS.Option = answers.Option;
                    //        ANS.Question = answers.Question;
                    //        ANS.QuestionId = answers.QuestionId;
                    //    }
                    //    ansList.Add(ANS);
                    //}
                    QuestionsList.Add(question);
                }
                //foreach (var answer in resultuser.ResultAnswer)
                //{
                //    var question = await _questionRepository.GetQuestionByIdAsync((Guid)answer.QuestionId);
                //    QuestionsList.Add(question);
                //}
                //for (int x = 0; x <= QuestionsList.Count(); x++) 
                //{
                //    var filter = QuestionsList.Where(x => x.Id == resultuser.ResultAnswer[0].QuestionId).FirstOrDefault();
                //    foreach (var a in filter.Answers) 
                //    {
                //        if (a.Id == resultuser.ResultAnswer[0].AnswerId)
                //        {
                //            a.IsCorrect = true;
                //        }
                //        else 
                //        {
                //            a.IsCorrect = false;
                //        }
                //        ANS.Question= 
                //    }
                //    QuestionsList2.Add(filter);
                //}

                userResult.users = userProfile.Content;
                userResult.result = resultuser;
                userResult.questionList = QuestionsList;
                apiResponse.Content = userResult;
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result> GetResultById(Guid resultId) 
        {
            try
            {
                return await _resultRespository.GetResultByIdAsync(resultId);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        } 
    }
}
