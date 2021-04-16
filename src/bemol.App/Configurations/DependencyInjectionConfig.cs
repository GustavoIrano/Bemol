using bemol.Business.Interfaces;
using bemol.Business.Notifications;
using bemol.Business.Services;
using bemol.Business.Services.ExternalServices;
using bemol.Data.Context;
using bemol.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace bemol.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BemolDbContext>();

            services.AddScoped<INotificator, Notificator>();

            //Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            //Services            
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IViaCepService, ViaCepService>();

            return services;
        }
    }
}
