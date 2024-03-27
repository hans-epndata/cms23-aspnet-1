using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configurations;

public static class DbContextConfiguration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer")));
    }
}
