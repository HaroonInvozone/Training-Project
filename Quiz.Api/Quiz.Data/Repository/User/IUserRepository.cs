using QuizApi;
using QuizApp.Model.DTOs;
using QuizApp.Model.Models;

namespace QuizApp.Data.Repository.User
{
    public interface IUserRepository
    {
        public Task<ApiResponse<Users>> CreateUser(UserDto userDto);
        public int SetRefreshToken(RefreshToken refreshToken, UserDto? userDto);
        public Task<ApiResponse<Users>> GenerateTokenThroughVerification(string refreshToken);
        public Task<ApiResponse<List<Users>>> GetUsersAsync();
        public Task<int> LogoutAsync(string refreshToken);
        public Task<ApiResponse<Users>> GetUsersByIdAsync(Guid userId);
        public Task<int> UpdateUser(UserDto userDto);
    }
}
