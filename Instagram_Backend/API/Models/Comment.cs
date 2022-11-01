using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Cmt { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostComment PostComment { get; set; }
        public int PostCommentId { get; set; }

    }
}