using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> getAllUser();
        Task<UserDto> getUserById(int id);
        Task<bool> updateUser(int id, UpdateUserDto updateUserDto);
        Task<bool> deleteUser(int id);
        Task<bool> ForgotPassword(string emailAddress);
        Task<bool> isUserPresent(int userId);
        Task<string> followOrUnfollow(FollowerDto followerDto);
    }
}