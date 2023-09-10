using System;
using System.Collections.Generic;

namespace IdentitySample.Entities
{
    public partial class Aspnetuser
    {
        public Aspnetuser()
        {
            Aspnetuserclaims = new HashSet<Aspnetuserclaim>();
            Aspnetuserlogins = new HashSet<Aspnetuserlogin>();
            Aspnetusertokens = new HashSet<Aspnetusertoken>();
            Roles = new HashSet<Aspnetrole>();
        }

        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public string? NormalizedUserName { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Aspnetuserclaim> Aspnetuserclaims { get; set; }
        public virtual ICollection<Aspnetuserlogin> Aspnetuserlogins { get; set; }
        public virtual ICollection<Aspnetusertoken> Aspnetusertokens { get; set; }

        public virtual ICollection<Aspnetrole> Roles { get; set; }
    }
}
