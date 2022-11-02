using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class LikeOrDislikePostDto
    {
        public int userId { get; set; }
        public int postId { get; set; }
    }
}