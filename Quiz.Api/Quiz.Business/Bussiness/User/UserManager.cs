
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApi;
using QuizApp.Data.Repository.User;
using QuizApp.Model.DTOs;
using QuizApp.Model.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace QuizApp.Business.Bussiness.User
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private const string timeOut = "Redirect to login please!";
        public UserManager(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Users> CreateUser(UserDto user) 
        {
            var result = await _userRepository.CreateUser(user);
            return result;
        }
        public async Task<Tuple<string , string>> Login(UserDto userDto) 
        {
            var token = CreateToken(userDto);
            RefreshToken refreshtoken = GenerateRefreshToken();
            _userRepository.SetRefreshToken(refreshtoken, userDto);
            return Tuple.Create(token, refreshtoken.Token);
        }
        public string CreateToken(UserDto userDto)
        {
            List<Claim> claims = new List<Claim>
            {
                //Create a logic to get role
                new Claim(ClaimTypes.Email, userDto.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            try
            {
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(2),
                Created = DateTime.Now
            };

            return refreshToken;
        }
        public async Task<string> GenerateTokenThroughVerification(string refreshToken) 
        {
            UserDto userDto = new UserDto();
            string result;
            var userData = await _userRepository.GenerateTokenThroughVerification(refreshToken);
            userDto.Email = userData.Email;
            if (userData.TokenExpires < DateTime.Now)
            {
                result = CreateToken(userDto);
            }
            else 
            {
                result = timeOut;
            }
            return result;
            
        }
    }
}
