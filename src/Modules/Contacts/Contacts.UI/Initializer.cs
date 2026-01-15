using Contacts.Infrastructure;
using Contacts.UI.JSInterop;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.UI
{
    public static class Initializer
    {
        public static void InitModule()
        {
            // This method is intentionally left blank.
            // It serves as an entry point to ensure the module is initialized.
        }

        public static IServiceCollection AddContactsUIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ExampleJsInterop>();

            return services;

        }


    }
}
