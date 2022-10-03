
using Quiz.Models.DTOs;
using QuizApi;
using QuizApp.Model.DTOs;
using QuizApp.Model.Models;

namespace QuizApp.Data.Repository.User
{
    public interface IUserRepository
    {
        public Task<ApiResponse<Users>> CreateUser(UserDto userDto);
        public void SetRefreshToken(RefreshToken refreshToken, UserDto? userDto);
        public Task<ApiResponse<Users>> GenerateTokenThroughVerification(string refreshToken);
    }
}
