using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.models;

namespace webapi.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}