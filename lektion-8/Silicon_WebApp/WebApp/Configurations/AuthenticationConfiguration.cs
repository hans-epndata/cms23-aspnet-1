using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Configurations;

public static class AuthenticationConfiguration
{
    public static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<UserEntity,IdentityRole>(x =>
        {
            x.User.RequireUniqueEmail = true;
            x.SignIn.RequireConfirmedAccount = false;
            x.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<ApplicationContext>();

        services.ConfigureApplicationCookie(x =>
        {
            x.LoginPath = "/signin";
            x.LogoutPath = "/signout";
            x.AccessDeniedPath = "/denied";
        });
    }
}
