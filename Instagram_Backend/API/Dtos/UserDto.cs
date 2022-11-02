using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        public string username { get; set; } = String.Empty;
        public string fullName { get; set; } = String.Empty;
        public string EmailAddress { get; set; } = String.Empty;
        public string profilePic { get; set; } = String.Empty;
        public string bio { get; set; } = String.Empty;
        public List<Post> Post { get; set; } = new List<Post>();


    }
}