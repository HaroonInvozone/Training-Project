using QuizApi;
using QuizApp.Model.DTOs;
using QuizApp.Model.Models;

namespace QuizApp.Business.Bussiness.User
{
    public interface IUserManager
    {
        public Task<Users> CreateUser(UserDto user);
        public Task<Tuple<string, string>> Login(UserDto user);
        public string CreateToken(UserDto userDto);
        public RefreshToken GenerateRefreshToken();
        public Task<string> GenerateTokenThroughVerification(string refreshToken);
    }
}
