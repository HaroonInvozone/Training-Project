using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quiz.Models.DTOs;
using QuizApi;
using QuizApp.Model.DTOs;
using QuizApp.Model.Models;
using QuizModels.Models;
using System.Security.Cryptography;
using System.Text;


namespace QuizApp.Data.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly QuizAppContext _context;
        private readonly IConfiguration _configuration;
        public const string SessionKeyId = "UserId";
        public Users user = new Users();
        //public HttpContext http;
        public UserRepository(QuizAppContext context, IConfiguration configuration)
        {
           _context = context;
           _configuration = configuration;
        }

        public async Task<ApiResponse<Users>?> CreateUser(UserDto userDto) 
        {
            try
            {
                var apiResponse = new ApiResponse<Users>();
                var users = new Users();
                users.Id = GenerateGuid(userDto.Email, userDto.Password);
                CreatePasswordHash(userDto.Password, out byte[] passwordhash, out byte[] passwordSalt);
                users.PasswordHash = passwordhash;
                users.PasswordSalt = passwordSalt;
                users.Role = userDto.Role;
                users.Email = userDto.Email;
                _context.Users.Add(users);
                _context.SaveChanges();
                apiResponse.Content = users;
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordSalt)
        {
            try 
            {
                using (var hmac = new HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Guid GenerateGuid(string name, string password) 
        {
            try 
            {
                string ForGuid = name + password;
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(ForGuid));
                    Guid result = new Guid(hash);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  void SetRefreshToken(RefreshToken refreshToken, UserDto userDto)
        {
            try 
            {
                var user = _context.Users.Where(x => x.Email == userDto.Email).FirstOrDefault();
                //var user = _context.User.FindAsync(userDto.Email);
                user.RefreshToken = refreshToken.Token;
                user.TokenCreated = refreshToken.Created;
                user.TokenExpires = refreshToken.Expires;
                _context.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ApiResponse<Users>> GenerateTokenThroughVerification(string refreshToken) 
        {
            try 
            {
                var users = new Users();
                var apiResponse = new ApiResponse<Users>();
                users = await _context.Users.Where(x => x.RefreshToken == refreshToken).FirstOrDefaultAsync();
                apiResponse.Content = users;
                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
        {
            try 
            {
                using (var hmac = new HMACSHA512(passwordSalt))
                {
                    var Computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return Computedhash.SequenceEqual(passwordhash);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
