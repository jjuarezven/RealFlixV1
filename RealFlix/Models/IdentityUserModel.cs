using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RealFlix.Models
{
	public class IdentityUserModel : IdentityUser
	{
		public ICollection<ApplicationUserRole> UserRoles { get; set; }
	}

	public class ApplicationUserRole : IdentityUserRole<string>
	{
		public virtual IdentityUserModel User { get; set; }
		public virtual ApplicationRole Role { get; set; }
	}

	public class ApplicationRole : IdentityRole
	{
		public ICollection<ApplicationUserRole> UserRoles { get; set; }
	}
}
