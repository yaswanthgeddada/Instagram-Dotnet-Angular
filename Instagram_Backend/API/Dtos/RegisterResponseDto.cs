using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RegisterResponseDto
    {
        public string token { get; set; }
        public string username { get; set; }
        public DateTime tokenExpiry { get; set; }
    }
}