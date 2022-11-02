using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class FollowerDto
    {
        public int userId { get; set; }
        public int followerId { get; set; }
    }
}