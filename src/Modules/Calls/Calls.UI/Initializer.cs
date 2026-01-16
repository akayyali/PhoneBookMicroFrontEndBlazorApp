using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calls.UI
{
    public static class Initializer
    {
        public static void InitModule()
        {
        }

        public static IServiceCollection AddContactsUIServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }


    }
}
