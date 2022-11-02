using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int PostId { get; set; }

    }
}