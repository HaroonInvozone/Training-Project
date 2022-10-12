﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                users.Name = userDto.UserName;
                users.Role = "User";
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

        public int SetRefreshToken(RefreshToken refreshToken, UserDto userDto)
        {
            try 
            {
                int result = 0;
                var user = _context.Users.Where(x => x.Email == userDto.Email).FirstOrDefault();
                if (user is null) 
                {
                    return result;
                }
                user.RefreshToken = refreshToken.Token;
                user.TokenCreated = refreshToken.Created;
                user.TokenExpires = refreshToken.Expires;
                _context.Update(user);
                result = _context.SaveChanges();
                return result;
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
        public async Task<ApiResponse<List<Users>>> GetUsersAsync()
        {
            try
            {
                var users = new List<Users>();
                var apiResponce = new ApiResponse<List<Users>>();
                users = await _context.Users.ToListAsync();
                apiResponce.Content = users;
                return apiResponce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> LogoutAsync(string refreshToken)
        {
            int result = 0;
            var user = await _context.Users.Where(x => x.RefreshToken == refreshToken).FirstOrDefaultAsync();
            if (user.RefreshToken is not null)
            {
                user.RefreshToken = string.Empty;
                _context.Update(user);
                result = _context.SaveChanges();
            }
            
            return result;
        }
    }
}
