using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UpdateUserDto
    {
        public string? fullName { get; set; }
        public string? emailAddress { get; set; }
        public string? bio { get; set; } = String.Empty;
        public string? profilePic { get; set; }
    }
}