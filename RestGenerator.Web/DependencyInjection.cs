using Microsoft.Extensions.DependencyInjection;
using RestGenerator.Infrastructure.Configurations;
using RestGenerator.Infrastructure.Configurations.Implementation;
using RestGenerator.DataAccess;
using RestGenerator.DataAccess.Implementation;
using RestGenerator.Service;
using RestGenerator.Service.Implementation;

namespace RestGenerator.Web
{
    internal static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurations, Configurations>();

            services.AddTransient<IFieldRepository, FieldRepository>();
            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<IApiRepository, ApiRepository>();

            services.AddTransient<IFieldService, FieldService>();
            services.AddTransient<IResourceService, ResourceService>();
            services.AddTransient<IApiService, ApiService>();
        }
    }
}
