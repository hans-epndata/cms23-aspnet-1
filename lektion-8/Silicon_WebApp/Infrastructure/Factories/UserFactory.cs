using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create(SignUpForm form)
    {
        try
        {
            return new UserEntity
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

    public static User Create(UserEntity userEntity) 
    {
        try
        {
            return new User
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email!,
                UserName = userEntity.Email!,
                PhoneNumber = userEntity.PhoneNumber,
                IsExternal = userEntity.IsExternal,
            };
        }
        catch { }
        return null!;
    }

    public static IEnumerable<User> Create(List<UserEntity> list)
    {
        var users = new List<User>();

        try
        {
            foreach(var user in list) 
                users.Add(Create(user));
        }
        catch { }
        return users;
    }
}
