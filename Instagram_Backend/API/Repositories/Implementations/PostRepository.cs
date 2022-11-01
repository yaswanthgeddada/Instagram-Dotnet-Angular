using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> addPost(Post post)
        {
            await _context.Posts.AddAsync(post);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            var p = await _context.Posts.FindAsync(id);

            if (p == null) return false;

            _context.Posts.Remove(p);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Post>> getAllPosts()
        {
            return await _context.Posts.Include(c => c.comments).ToListAsync(); ;
        }

        public async Task<IEnumerable<Post>> getAllUserPosts(int userId)
        {
            var posts = await _context.Posts.Include(c => c.comments).Where(u => u.AppUserId == userId).ToListAsync();

            return posts;
        }


        public async Task<Post> getPostbyId(int id)
        {
            return await _context.Posts.Include(c => c.comments).SingleAsync(p => p.Id == id);
        }
    }
}