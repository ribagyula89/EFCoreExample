using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EFCoreExample.Entities.Models
{
    public class Role : IdentityRole<int>
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string NormalizedName { get; set; }
        public override string ConcurrencyStamp { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}