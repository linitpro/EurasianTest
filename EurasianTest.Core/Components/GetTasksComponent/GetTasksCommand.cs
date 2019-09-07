using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.Core.Queries.GetProjectsStrategy;
using EurasianTest.Core.Queries.GetTasksStrategy;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.GetTasksComponent
{
    public class GetTasksCommand: ICommand<GetTasksViewModel, GetTasksViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly GetTasksStrategy getTasksStrategy;
        private readonly GetProjectsStrategy getProjectsStrategy;

        public GetTasksCommand(DataContext dataContext
            , IMapper mapper
            , GetTasksStrategy getTasksStrategy
            , GetProjectsStrategy getProjectsStrategy
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
            this.getTasksStrategy = getTasksStrategy ?? throw new NotImplementedException(nameof(GetTasksStrategy));
            this.getProjectsStrategy = getProjectsStrategy ?? throw new NotImplementedException(nameof(GetProjectsStrategy));
        }

        public async Task<GetTasksViewModel> ExecuteAsync(GetTasksViewModel request)
        {
            request.Items = await getTasksStrategy.Query.ExecuteAsync();
            request.Projects = await this.getProjectsStrategy.Query.ExecuteAsync();
            return request;
        }
    }
}
