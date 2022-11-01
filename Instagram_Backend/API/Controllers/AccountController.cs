using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;

        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseDto>> registerUser(RegisterDto registerDto)
        {
            if (registerDto == null) return NotFound();

            var user = new AppUser();

            var hmac = new HMACSHA512();

            user.UserName = registerDto.username;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password));
            user.PasswordSalt = hmac.Key;

            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return new RegisterResponseDto
            {
                token = _tokenService.createToken(user),
                username = registerDto.username,
                tokenExpiry = DateTime.Now.AddDays(2)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<RegisterResponseDto>> userLogin(LoginDto loginDto)
        {
            if (loginDto == null) return NotFound();

            var user = _context.AppUsers.SingleOrDefault(u => u.UserName == loginDto.username);

            if (user == null) return BadRequest("UserNotFound");

            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));

            var isValid = computedHash.SequenceEqual(user.PasswordHash);

            if (!isValid) return BadRequest("Wrong password");

            return new RegisterResponseDto
            {
                token = _tokenService.createToken(user),
                tokenExpiry = DateTime.Now.AddDays(2),
                username = user.UserName
            };
        }

    }
}