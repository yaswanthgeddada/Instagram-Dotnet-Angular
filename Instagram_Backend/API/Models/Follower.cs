using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Follower
    {
        public int Id { get; set; }

        [JsonIgnore]
        [NotMapped]
        public AppUser follower { get; set; } = default!;
        public int followerId { get; set; } = default!;

        [JsonIgnore]
        [NotMapped]
        public AppUser user { get; set; } = default!;
        public int userId { get; set; } = default!;

    }
}