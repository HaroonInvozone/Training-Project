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
        public const string SessionKeyId = "UserId";
        public Users user = new Users();
        //public HttpContext http;
        public UserRepository(QuizAppContext context, IConfiguration configuration)
        {
           _context = context;
           _configuration = configuration;
        }

        public async Task<Users?> CreateUser(UserDto userDto) 
        {
            Users users = new Users();
            users.Id = GenerateGuid(userDto.Email, userDto.Password);
            CreatePasswordHash(userDto.Password, out byte[] passwordhash, out byte[] passwordSalt);
            users.PasswordHash = passwordhash;
            users.PasswordSalt = passwordSalt;
            users.Role = userDto.Role;
            users.Email = userDto.Email;
            _context.Users.Add(users);
            var response = _context.SaveChanges();
            return response > 0 ? users : null;
        }
        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private Guid GenerateGuid(string name, string password) 
        {
            string ForGuid = name + password;
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(ForGuid));
                Guid result = new Guid(hash);
                return result;
            }
        }

        public  void SetRefreshToken(RefreshToken refreshToken, UserDto userDto)
        {
            var user = _context.Users.Where(x => x.Email == userDto.Email).FirstOrDefault();
            //var user = _context.User.FindAsync(userDto.Email);
            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpires = refreshToken.Expires;
            _context.Update(user);
            _context.SaveChanges();
        }
        public async Task<Users> GenerateTokenThroughVerification(string refreshToken) 
        {
            Users users = new Users();
            users = await _context.Users.Where(x => x.RefreshToken == refreshToken).FirstOrDefaultAsync();
            return users;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var Computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Computedhash.SequenceEqual(passwordhash);
            }
        }
    }
}
