using InvoPassport.Model.DTOs;
using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;

namespace InvoPassport.Business.Bussiness.User
{
    public interface IUserManager
    {
        public Task<Users> CreateUser(UserDto user);
        public Task<ApiResponse<AuthResponse>> Login(UserDto user);
        public string CreateToken(UserDto userDto);
        public RefreshToken GenerateRefreshToken();
        public Task<ApiResponse<AuthResponse>> GenerateTokenThroughVerification(string refreshToken);
        public Task<ApiResponse<List<Users>>> GetUsersAsync();
        public Task<ApiResponse<string>> LogoutAsync(TokenApiModel tokenApiModel);
        public Task<ApiResponse<Users>> GetUsersByIdAsync(Guid userId);
        public Task<Users> UpdateUser(UserDto userDto);
    }
}
