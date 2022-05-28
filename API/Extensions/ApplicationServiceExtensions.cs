using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
             services.AddScoped<ITokenService, TokenService>();
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