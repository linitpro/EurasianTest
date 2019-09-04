using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.Core.Queries.GetProjectsStrategy;
using EurasianTest.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetProjectsComponent
{
    public class GetProjectsCommand: ICommand<GetProjectsViewModel, GetProjectsViewModel>
    {
        private readonly DataContext dataContext;
        private readonly GetProjectsStrategy getProjectsStrategy;
        private readonly IAuthContext authContext;

        public GetProjectsCommand(DataContext dataContext
            , GetProjectsStrategy getProjectsStrategy
            , IAuthContext authContext
            )
        {
            this.dataContext = dataContext;
            this.getProjectsStrategy = getProjectsStrategy;
            this.authContext = authContext;
        }

        public async System.Threading.Tasks.Task<GetProjectsViewModel> ExecuteAsync(GetProjectsViewModel request)
        {
            request.Projects = await this.getProjectsStrategy.Query.ExecuteAsync();
            return request;
        }
    }
}
