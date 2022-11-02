using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public List<Like> likes { get; set; } = default!;

        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        public int AppUserId { get; set; }

        public List<Comment>? comments { get; set; }

    }
}