using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ITokenService
    {
        string createToken(AppUser user);
        string tokkenUserName();
        Task<bool> isUserTrueUser(int userId);
    }
}