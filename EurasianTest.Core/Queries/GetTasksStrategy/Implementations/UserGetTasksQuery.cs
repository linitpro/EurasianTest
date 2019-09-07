using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetTasksStrategy.Implementations
{
    public class UserGetTasksQuery : IGetTasksQuery
    {
        public Role Role
        {
            get
            {
                return Role.User;
            }
        }

        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IAuthContext authContext;

        public UserGetTasksQuery(DataContext dataContext
            , IMapper mapper
            , IAuthContext authContext
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
            this.authContext = authContext ?? throw new NotImplementedException(nameof(IAuthContext));
        }

        public async Task<List<GetTasksItemViewModel>> ExecuteAsync(GetTasksViewModel request)
        {
            Int64 userId = this.authContext.CurrentUser.Id;

            var query = dataContext
                .Tasks
                .Where(x => x.IsDeleted == false && x.Project.ProjectAdministrators.Any(a => a.UserId == userId && a.IsDeleted == false));

            if (request.ProjectIdFilter != null)
            {
                query = query.Where(x => x.ProjectId == request.ProjectIdFilter.Value);
            }

            if (request.TaskStatusFilter != null)
            {
                query = query.Where(x => x.Status == request.TaskStatusFilter.Value);
            }

            if (request.UserIdFilter != null)
            {
                query = query.Where(x => x.UserId == request.UserIdFilter.Value);
            }

            return await query.ProjectTo<GetTasksItemViewModel>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
