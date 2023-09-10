
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentitySample.Identity
{
     public class SampleIdentityContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public SampleIdentityContext(DbContextOptions<SampleIdentityContext> options): base(options)
        {

        }
    }

 
}