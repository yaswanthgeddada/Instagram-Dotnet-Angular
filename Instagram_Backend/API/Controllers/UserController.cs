using API.Data;
using API.Dtos;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UserController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserController(DataContext context, IMapper mapper, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> getAllUsers()
        {
            var users = await _context.AppUsers.ToListAsync();

            return Ok(users);
        }

        [HttpGet("getuserbyid/{Id:int}")]
        public async Task<IActionResult> getAllUsers(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);

            return Ok(user);
        }


        [HttpPost("adduser")]
        public async Task<IActionResult> addUser(AppUser appUser)
        {
            await _context.AppUsers.AddAsync(appUser);

            await _context.SaveChangesAsync();

            return Ok(appUser);
        }
    }
}
