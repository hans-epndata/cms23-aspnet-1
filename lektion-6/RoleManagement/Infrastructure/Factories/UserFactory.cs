using Infrastructure.Identity;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static ApplicationUser Create(string firstName, string lastName, string email)
    {
        try
        {
            return new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email
            };
        }
        catch { }
        return null!;
    }
}
