using DataTransit.Application.Interfaces;
using DataTransit.Application.Services;
using DataTransit.Data.Context;
using DataTransit.Data.Repository;
using DataTransit.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataTransit.Ioc
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataTransitService(this IServiceCollection services, string SqlConnectionstring,string RedisConnectionstring)
        {
            
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IDataTransitService, DataTransitService>();
            services.AddDbContext<DataTransitContext>(option=> 
            {
                option.UseSqlServer(SqlConnectionstring);
            });
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = RedisConnectionstring;
            });
            
            return services;
        }
    }
}
