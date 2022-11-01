using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);

            if (user == null) return false;

            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> ForgotPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> getAllUser()
        {
            var users = await _context.AppUsers.ToListAsync();

            var mappedUsers = _mapper.Map<IEnumerable<UserDto>>(users);

            return mappedUsers;

        }

        public async Task<UserDto> getUserById(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);


            var mappedUser = _mapper.Map<UserDto>(user);

            return mappedUser;
        }

        public async Task<bool> updateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = await _context.AppUsers.FindAsync(id);
            if (user == null) return false;
            user.Bio = updateUserDto.bio == null ? user.Bio : updateUserDto.bio;
            user.FullName = updateUserDto.fullName == null ? user.FullName : updateUserDto.fullName;
            user.EmailAddress = updateUserDto.emailAddress == null ? user.EmailAddress : updateUserDto.emailAddress;
            user.ProfilePic = updateUserDto.profilePic == null ? user.ProfilePic : updateUserDto.profilePic;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}