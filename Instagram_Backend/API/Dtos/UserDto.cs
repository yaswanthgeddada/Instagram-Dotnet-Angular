using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string fullName { get; set; }
        public string EmailAddress { get; set; }
        public string profilePic { get; set; }
        public string bio { get; set; }

    }
}