using InvoPassport;
using InvoPassport.Business.Bussiness.User;
using InvoPassport.Data.Repository.User;
using InvoPassport.Model.DTOs;
using InvoPassport.Model.Models;
using InvoPassport.Models.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace QuizApp.Business.Bussiness.User
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private const string timeOut = "Logout Please...";
        public UserManager(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Users> CreateUser(UserDto user)
        {
            try 
            {
                var result = await _userRepository.CreateUser(user);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<AuthResponse>> Login(UserDto userDto)
        {
            try
            {
                var apiResponse = new ApiResponse<AuthResponse>();
                var authResponse = new AuthResponse();
                var token = CreateToken(userDto);
                var refreshtoken = GenerateRefreshToken();
                int result = _userRepository.SetRefreshToken(refreshtoken, userDto);
                if(result.Equals(0))
                    return apiResponse; 
                authResponse.AccessToken = token;
                authResponse.RefreshToken = refreshtoken.Token;
                apiResponse.Content = authResponse;
                //return Tuple.Create(token, refreshtoken.Token);
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string CreateToken(UserDto userDto)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                    //Create a logic to get role
                    new Claim(ClaimTypes.Email, userDto.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                    //new Claim(ClaimTypes.Role, "User")
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));
                //_configuration.GetSection("Jwt:Key").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(2),
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
            try 
            {
                var refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                    Expires = DateTime.Now.AddDays(2),
                    Created = DateTime.Now
                };

                return refreshToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<AuthResponse>> GenerateTokenThroughVerification(string refreshToken)
        {
            try 
            {
                var userDto = new UserDto();
                var authResponse = new AuthResponse();
                var apiResponcse = new ApiResponse<AuthResponse>();
                var userData = await _userRepository.GenerateTokenThroughVerification(refreshToken);
                userDto.Email = userData.Content.Email;
                if (userData.Content.TokenExpires > DateTime.Now)
                {
                    authResponse.AccessToken = CreateToken(userDto);
                    authResponse.RefreshToken = refreshToken;
                    apiResponcse.Content = authResponse;
                }
                else
                {
                    apiResponcse.Message = timeOut;
                    apiResponcse.Content = authResponse;
                }
                return apiResponcse;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<List<Users>>> GetUsersAsync() 
        {
            try
            {
                var apiResponce = new ApiResponse<List<Users>>();
                var result = await _userRepository.GetUsersAsync();
                apiResponce.Content = result.Content;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<Users>> GetUsersByIdAsync(Guid userId) 
        {
            try {
                var apiResponce = new ApiResponse<Users>();
                var result = await _userRepository.GetUsersByIdAsync(userId);
                apiResponce.Content = result.Content;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Users> UpdateUser(UserDto userDto) 
        {
            try
            {
                return await _userRepository.UpdateUser(userDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<string>> LogoutAsync(TokenApiModel tokenApiModel)
        {
            try
            {
                var apiResponce = new ApiResponse<string>();
                int result = await _userRepository.LogoutAsync(tokenApiModel.RefreshToken);
                if (result.Equals(1))
                {
                    apiResponce.Message = "Logout Successfully";
                    apiResponce.Status = HttpStatusCode.OK;
                }
                else
                {
                    apiResponce.Message = "Invalid token";
                    apiResponce.Status = HttpStatusCode.NotFound;
                }
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
