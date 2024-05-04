using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApiDbContext: IdentityDbContext<AppUser>
    {
        public ApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}