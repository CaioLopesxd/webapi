using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace webapi.models
{
    public class AppUser : IdentityUser
    {
        public List<Portifolio> Portifolios { get; set; } = new List<Portifolio>();
    }
}