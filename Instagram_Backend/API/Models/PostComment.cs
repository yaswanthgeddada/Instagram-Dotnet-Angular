using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class PostComment
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Comment Comment { get; set; }
        public int CommentId { get; set; }

        [JsonIgnore]
        public Post Post { get; set; }
        public int PostId { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}