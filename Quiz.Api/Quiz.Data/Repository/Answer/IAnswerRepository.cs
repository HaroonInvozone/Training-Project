using Quiz.Models.DTOs;
using Quiz.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Data.Repository.Answers
{
    public interface IAnswerRepository
    {
        public Task<Guid> GetCorrectAnswer(Guid Questionguid);
        public Task<Guid> GetResultId(Guid UserId);
        public Task<int> GetAllAnswersNumber();
        public Task<string> SaveAnswerAsync(ResultAnswer resultAnswer);
        public Task<string> SaveResult(Guid ResultId);
        public Task<Result> GetResultAsync(GetResult getResult);
    }
}
