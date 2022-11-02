using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interfaces
{
    public interface IPostRepository
    {

        Task<bool> addPost(Post post);
        Task<bool> DeletePost(int id);
        Task<IEnumerable<Post>> getAllPosts();
        Task<IEnumerable<Post>> getAllUserPosts(int id);

        Task<Post> getPostbyId(int id);
        Task<string> likeOrDisLikePost(LikeOrDislikePostDto reqDto);
        Task<bool> isPostPresent(int postId);



    }
}