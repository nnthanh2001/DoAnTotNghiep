using BusinessLogicLayer.BusinessWrapper;
using Contracts.AQL;
using Contracts.RepositoryWrapper;
using DataAccessLayer.BusinessWrapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Repository.AQL;
using Repository.RepositoryWrapper;

namespace DATN_API.Services
{
    public static class AppConfig
    {
        public static void ConfigureMongo(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("DiaDiem");
            services.AddSingleton<IMongoClient>(sp =>
            {
                return new MongoClient(connection);
            });

        }
        public static void ConfigureTransientService(this IServiceCollection services)
        {
            services.AddScoped<IBusinessWrapper, BusinessWrapper>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<IQuery, Query>();
        }
    }
}
