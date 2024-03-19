using Microsoft.AspNetCore.Identity;

namespace WebApp_IndividualAccounts_Authentication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;   
    }
}
