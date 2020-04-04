using Microsoft.AspNetCore.Identity;

namespace EFCoreExample.Entities.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public override int UserId { get; set; }
        public override int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
