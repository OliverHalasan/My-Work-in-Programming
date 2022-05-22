#region Additional Nmespaces
using AppSecurity.Models;
using Microsoft.AspNetCore.Identity;
#endregion

namespace BikesRUs.Data
{
    public class ApplicationUser : IdentityUser, IIdentifyEmployee
    {
        public int? EmployeeId { get; set; }
    }
}
