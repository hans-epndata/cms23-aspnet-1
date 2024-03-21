using Microsoft.AspNetCore.Identity;
using WebApp.Models;

namespace WebApp.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;


    public static implicit operator ApplicationUser(RegistrationForm form)
    {
        try
        {
            return new ApplicationUser
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                UserName = form.Email
            };
        }
        catch { }
        return null!;
    }

}
