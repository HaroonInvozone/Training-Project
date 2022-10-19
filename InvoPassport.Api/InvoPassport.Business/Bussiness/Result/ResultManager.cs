using InvoPassport.Data.Repository.QuestionAnswer;
using InvoPassport.Data.Repository.Results;
using InvoPassport.Data.Repository.User;
using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using InvoPassport.Models.Models;

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
        public async Task<List<Result>> GetAllResult() 
        {
            try
            {
               return await _resultRespository.GetAllResult();    
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        //do not delete this function is used for to get the result by id
        public async Task<ApiResponse<UserResult>> GetResultAsync(Guid ResultId)
        {
            try
            {
                var apiResponse = new ApiResponse<UserResult>();
                var userResult = new UserResult();
                var Questions1 = new UserAttempt();
                var Questions1List = new List<UserAttempt>();
                int count = 0;

                //var userProfile = await _userRepository.GetUsersByIdAsync(getResult.UserId);
                var resultuser = await _resultRespository.GetResultByIdAsync(ResultId);
                //var x = await _resultRespository.GetResultCompleteByIdAsync(ResultId);
                var userProfile = resultuser.User;
                foreach (var answer in resultuser.ResultAnswer)
                {
                    var question = await _questionRepository.GetQuestionByIdAsync((Guid)answer.QuestionId);
                    foreach (var answers in question.Answers)
                    {
                        if (answers.Id == answer.AnswerId && answers.IsCorrect is true)
                        {
                            Questions1.Title = question.Title;
                            Questions1.IsCorrect = true;
                            count++;
                            break;
                        }
                    }
                    if (count.Equals(0))
                    {
                        Questions1.Title = question.Title;
                        Questions1.IsCorrect = false;
                    }
                    count = 0;
                    Questions1List.Add(Questions1);
                }
                userResult.users = new Users 
                {
                    FirstName = userProfile.FirstName,
                    lastName = userProfile.lastName,
                    Email = userProfile.Email,
                    JobTitle = userProfile.JobTitle
                };
                userResult.result = new Result
                {
                    Test_Date = resultuser.Test_Date,
                    StartTime = resultuser.StartTime,
                    EndTime = resultuser.EndTime,
                    CorrectAnswer = resultuser.CorrectAnswer,
                    TotalQuestion = resultuser.CorrectAnswer,
                    CurrentState = resultuser.CurrentState
                }; ;
                userResult.UserAttempt = Questions1List;
                apiResponse.Content = userResult;
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Result?>> GetCompleteResultAsync() 
        {
            return await _resultRespository.GetCompleteResultByIdAsync();
        }
    }
}
