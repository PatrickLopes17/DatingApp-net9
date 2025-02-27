using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationservices(this IServiceCollection services, IConfiguration config)
    {
        
       services.AddControllers();
       services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

       services.AddCors();
       services.AddScoped<ITokenService, TokenService>(); // interface and implementation class

       return services;
    }
}
