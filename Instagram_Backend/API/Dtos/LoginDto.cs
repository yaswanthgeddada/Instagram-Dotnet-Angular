using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class LoginDto
    {
        public string username { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
    }
}