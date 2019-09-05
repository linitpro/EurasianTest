using EurasianTest.Core.Components.AddProjectComponent;
using EurasianTest.Core.Components.AddTaskComponent;
using EurasianTest.Core.Components.AuthorizationComponent;
using EurasianTest.Core.Components.ChangeTaskStatusComponent;
using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent;
using EurasianTest.Core.Components.GetHomeInfoModel;
using EurasianTest.Core.Components.GetProjectDetailsComponent;
using EurasianTest.Core.Components.GetProjectsComponent;
using EurasianTest.Core.Components.GetTaskDetailsComponent;
using EurasianTest.Core.Components.GetTasksComponent;
using EurasianTest.Core.Components.GetUsersComponent;
using EurasianTest.Core.Components.OuterRegistrationComponent;
using EurasianTest.Core.Components.UpdateProjectComponent;
using EurasianTest.Core.Components.UpdateTaskComponent;
using EurasianTest.Core.Infrastructure;
using EurasianTest.Core.Queries.GetHomeAdminInfoQuery;
using EurasianTest.Core.Queries.GetHomeAdminInfoQuery.Implementations;
using EurasianTest.Core.Queries.GetProjectDetailsStrategy;
using EurasianTest.Core.Queries.GetProjectDetailsStrategy.Implementations;
using EurasianTest.Core.Queries.GetProjectsStrategy;
using EurasianTest.Core.Queries.GetProjectsStrategy.Implementations;
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
            services.AddTransient<GetProjectsCommand>();
            services.AddTransient<AddProjectCommand>();
            services.AddTransient<GetProjectDetailsCommand>();
            services.AddTransient<UpdateProjectCommand>();
            services.AddTransient<GetUsersDictionaryCommand>();
            services.AddTransient<GetProjectsDictionaryCommand>();
            services.AddTransient<AddTaskCommand>();
            services.AddTransient<GetTaskDetailsCommand>();
            services.AddTransient<GetTasksCommand>();
            services.AddTransient<ChangeTaskStatusCommand>();
            services.AddTransient<UpdateTaskCommand>();
            services.AddTransient<GetHomeInfoCommand>();

            services.AddScoped<IAuthContext, AuthContext>();

            services.AddTransient<GetProjectsStrategy>();
            services.AddTransient<IGetProjectsQuery, UserGetProjectsQuery>();
            services.AddTransient<IGetProjectsQuery, ProjectAdministratorGetProjectsQuery>();
            services.AddTransient<IGetProjectsQuery, AdministratorGetProjectsQuery>();

            services.AddTransient<GetProjectDetailsStrategy>();
            services.AddTransient<IGetProjectDetailsQuery, AdministratorGetProjectDetailsQuery>();
            services.AddTransient<IGetProjectDetailsQuery, ProjectAdministratorGetProjectDetailsQuery>();
            services.AddTransient<IGetProjectDetailsQuery, UserGetProjectDetailsQuery>();

            services.AddTransient<GetHomeadminInfoStrategy>();
            services.AddTransient<IGetHomeadminInfoQuery, AdministratorGetHomeadminInfoQuery>();
            services.AddTransient<IGetHomeadminInfoQuery, ProjectAdministratorGetHomeadminInfoQuery>();
            services.AddTransient<IGetHomeadminInfoQuery, UserGetHomeadminInfoQuery>();

            return services;
        }
    }
}
