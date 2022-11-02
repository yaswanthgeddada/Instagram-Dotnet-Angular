using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Repositories.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    public class PostController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        public PostController(IMapper mapper, IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet("getAllPosts")]
        public async Task<ActionResult<Post>> getallPosts()
        {
            var posts = await _postRepository.getAllPosts();

            return Ok(posts);
        }


        [HttpGet("getAllUserPosts/{id}")]
        public async Task<ActionResult<Post>> getAllUserPosts(int id)
        {
            var posts = await _postRepository.getAllUserPosts(id);

            return Ok(posts);
        }

        [HttpPost("addpost")]
        public async Task<ActionResult<Post>> addPost(Post post)
        {
            var res = await _postRepository.addPost(post);

            return Ok(res);
        }

        [HttpDelete("deletepost/{postId}")]
        public async Task<IActionResult> deletePost(int postId)
        {
            var res = await _postRepository.DeletePost(postId);
            if (!res) return BadRequest("Delete unsuccessfull");

            return Ok("deleted successfully");
        }

        [HttpGet("getpostbyid/{id}")]
        public async Task<ActionResult<PostDto>> getPostById(int id)
        {
            if (!await _postRepository.isPostPresent(id)) return BadRequest("Post not present");

            var post = await _postRepository.getPostbyId(id);

            return Ok(post);
        }

        [HttpPut("likeOrDislikePost")]
        public async Task<IActionResult> likeOrDisLikePost(LikeOrDislikePostDto reqDto)
        {
            var res = await _postRepository.likeOrDisLikePost(reqDto);

            if (res == "Liked")
            {
                return Ok("like added");
            }
            else if (res == "DisLiked")
            {
                return Ok("Disliked");
            }

            return BadRequest("failed to like or dislike the post");
        }

    }
}