using InvoPassport.Model.DTOs;
using InvoPassport.Model.Models;

namespace InvoPassport.Data.Repository.User
{
    public interface IUserRepository
    {
        public Task<Users> CreateUser(UserDto userDto);
        public int SetRefreshToken(RefreshToken refreshToken, UserDto? userDto);
        public Task<ApiResponse<Users>> GenerateTokenThroughVerification(string refreshToken);
        public Task<ApiResponse<List<Users>>> GetUsersAsync();
        public Task<int> LogoutAsync(string refreshToken);
        public Task<ApiResponse<Users>> GetUsersByIdAsync(Guid userId);
        public Task<Users> UpdateUser(UserDto userDto);
    }
}
