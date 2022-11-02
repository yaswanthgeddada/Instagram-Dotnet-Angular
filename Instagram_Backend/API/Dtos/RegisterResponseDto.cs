using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RegisterResponseDto
    {
        public string token { get; set; } = String.Empty;
        public string username { get; set; } = String.Empty;
        public DateTime tokenExpiry { get; set; }
    }
}