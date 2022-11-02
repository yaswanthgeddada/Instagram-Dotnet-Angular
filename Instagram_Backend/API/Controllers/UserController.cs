using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Data;
using API.Dtos;
using API.Models;
using API.Repositories.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, ITokenService tokenService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpGet("getusers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> getAllUsers()
        {
            var users = await _userRepository.getAllUser();

            return Ok(users);
        }

        [HttpGet("getuserbyid/{id}")]
        public async Task<ActionResult<UserDto>> getuserbyid(int id)
        {


            var tokenHandler = new JwtSecurityTokenHandler();

            // var t = tokenHandler.ReadJwtToken()
            // var u = t.Claims.First(c => c.Type == "nameid").Value;


            var user = await _userRepository.getUserById(id);

            var email = User.FindFirst("UserName")?.Value;

            if (user == null) return BadRequest($"User not found with id:{id}");

            return Ok(user);
        }


        [HttpPut("updateUser")]
        public async Task<IActionResult> updateUser([FromQuery] int id, UpdateUserDto updateUserDto)
        {
            var res = await _userRepository.updateUser(id, updateUserDto);
            var user = await _userRepository.getUserById(id);

            if (!res) return BadRequest("Update Failed");

            return Ok(user);
        }

        [HttpDelete("deactiveuser/{id:int}")]
        public async Task<IActionResult> deleteUser(int id)
        {



            if (await _userRepository.isUserPresent(id) && await _tokenService.isUserTrueUser(id))
            {
                var res = await _userRepository.deleteUser(id);
                if (res) return Ok("Account deactivated successfully");
            }

            return Unauthorized();
        }
    }
}
