using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetUsersStrategy.Implementations
{
    public class ProjectAdministratorGetUsersQuery : IGetUsersQuery
    {
        public Role Role
        {
            get
            {
                return Role.ProjectAdministrator;
            }
        }

        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IAuthContext authContext;

        public ProjectAdministratorGetUsersQuery(DataContext dataContext
            , IMapper mapper
            , IAuthContext authContext
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
            this.authContext = authContext ?? throw new NotImplementedException(nameof(IAuthContext));
        }

        public async Task<List<UserViewModel>> ExecuteAsync()
        {
            Int64 userId = this.authContext.CurrentUser.Id;

            return await dataContext
                .Users
                .Where(x => x.IsDeleted == false && x.Projects.Any(a => a.UserId == userId))
                .ProjectTo<UserViewModel>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.Email)
                .ToListAsync();
        }
    }
}
