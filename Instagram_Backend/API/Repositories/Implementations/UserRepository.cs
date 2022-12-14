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

        public async Task<bool> deleteUser(int id)
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
            var users = await _context.AppUsers.Include(p => p.Post).ToListAsync();

            var mappedUsers = _mapper.Map<IEnumerable<UserDto>>(users);

            return mappedUsers;

        }

        public async Task<UserDto> getUserById(int id)
        {
            var user = await _context.AppUsers.Include(p => p.Post).ThenInclude(c => c.comments).FirstAsync(u => u.Id == id);

            var followers = await _context.Followers.Where(f => f.userId == user.Id).ToListAsync();
            var following = await _context.Followers.Where(f => f.followerId == user.Id).ToListAsync();


            user.Followers = followers;
            user.Following = following;


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

        public async Task<bool> isUserPresent(int userId)
        {
            return await _context.AppUsers.AnyAsync(u => u.Id == userId) ? true : false;
        }

        public async Task<string> followOrUnfollow(FollowerDto followerDto)
        {
            if (!await isUserPresent(followerDto.userId) || !await isUserPresent(followerDto.followerId)) return "user not found";
            string res = String.Empty;

            var user = await _context.AppUsers.FindAsync(followerDto.userId);
            var follower = await _context.AppUsers.FindAsync(followerDto.followerId);

            var isFollowing = await _context.Followers.AnyAsync(u => u.userId == followerDto.userId && u.followerId == followerDto.followerId);

            if (user != null && user.Followers.Count == 0 && !isFollowing)
            {
                _context.Followers.Add(new Follower { userId = user.Id, followerId = followerDto.followerId });
                res = "Followed";
                await _context.SaveChangesAsync();

                return res;
            }


            var followingUser = await _context.Followers.FirstOrDefaultAsync(u => u.userId == followerDto.userId && u.followerId == followerDto.followerId);




            if (follower != null && isFollowing)
            {
                _context.Followers.Remove(followingUser!);
                res = "UnFollowed";
            }
            else
            {
                _context.Followers.Add(followingUser!);
                res = "Followed";
            }

            await _context.SaveChangesAsync();

            return res;
        }


    }
}