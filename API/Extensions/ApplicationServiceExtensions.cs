using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
             services.AddScoped<ITokenService, TokenService>();
             services.AddScoped<IUserRepository, UserRepository>();
             services.AddAutoMapper(typeof(AutoMappersProfiles).Assembly);
             services.AddDbContext<DataContext>(options =>
            {
#pragma warning disable CS8604 // Possible null reference argument.
                _ = options.UseSqlite(config.GetConnectionString("DefaultConnection"));
#pragma warning restore CS8604 // Possible null reference argument.
            });

            return services;
        }
    }
}