using Microsoft.AspNetCore.Identity;

namespace IdentitySample.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }

}
