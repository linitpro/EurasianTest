using EurasianTest.Core.Components.AuthorizationComponent;
using EurasianTest.Core.Components.GetUsersComponent;
using EurasianTest.Core.Components.OuterRegistrationComponent;
using EurasianTest.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core
{
    public static class CoreExtensions
    {
        public static IServiceCollection RegisterCoreTypes(this IServiceCollection services)
        {
            services.AddTransient<UnitOfWork>();

            services.AddTransient<OuterRegistrationCommand>();
            services.AddTransient<AuthorizationCommand>();
            services.AddTransient<GetUsersCommand>();

            return services;
        }
    }
}
