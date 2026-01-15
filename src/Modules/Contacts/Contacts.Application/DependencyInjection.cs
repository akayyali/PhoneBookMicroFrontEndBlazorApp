using Contacts.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Contacts.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContactsApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            services.AddContactsInfrastructure(configuration);

            //services.AddScoped<IAnySomeService, AnySomeService>();

            return services;
        }
    }
}
