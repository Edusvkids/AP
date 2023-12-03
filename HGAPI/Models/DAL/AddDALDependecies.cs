using Microsoft.EntityFrameworkCore;

namespace HGAPI.Models.DAL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HGAPIContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Conn"))
            );

            ///////////////////////////////////////////////////////////
            services.AddAuthDependecies();
            ///////////////////////////////////////////////////////////

            services.AddScoped<UserPlayerDAL>();
            services.AddScoped<AccountDAL>();
            services.AddScoped<ProductGamesDAL>();
            return services;
        }
    }
}
