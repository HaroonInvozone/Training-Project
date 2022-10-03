using Quiz.Models.DTOs;
using QuizApi;
using QuizApp.Model.DTOs;
using QuizApp.Model.Models;

namespace QuizApp.Business.Bussiness.User
{
    public interface IUserManager
    {
        public Task<ApiResponse<Users>> CreateUser(UserDto user);
        public Task<ApiResponse<AuthResponse>> Login(UserDto user);
        public string CreateToken(UserDto userDto);
        public RefreshToken GenerateRefreshToken();
        public Task<ApiResponse<AuthResponse>> GenerateTokenThroughVerification(string refreshToken);
    }
}
