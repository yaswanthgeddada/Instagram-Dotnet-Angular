using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<int> likes { get; set; } = default!;
        public int AppUserId { get; set; }
    }
}