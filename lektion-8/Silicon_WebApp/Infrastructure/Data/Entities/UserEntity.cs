using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Entities;

public class UserEntity : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsExternal { get; set; }
}
