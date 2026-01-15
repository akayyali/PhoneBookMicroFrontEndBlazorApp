using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContactsInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ContactsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                    //,b => b.MigrationsHistoryTable("__EFMigrationsHistory", "contacts")
                    ));

            //services.AddScoped<ISomeService, SomeService>();

            return services;
        }
    }

}
