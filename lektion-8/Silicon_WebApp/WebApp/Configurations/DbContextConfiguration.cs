using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;


namespace WebApp.Configurations;

public static class DbContextConfiguration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer")));
    }
}
