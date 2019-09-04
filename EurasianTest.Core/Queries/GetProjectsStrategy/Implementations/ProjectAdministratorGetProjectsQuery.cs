using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetProjectsStrategy.Implementations
{
    public class ProjectAdministratorGetProjectsQuery : IGetProjectsQuery
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

        public ProjectAdministratorGetProjectsQuery(DataContext dataContext
            , IMapper mapper
            , IAuthContext authContext
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
            this.authContext = authContext ?? throw new NotImplementedException(nameof(IAuthContext));
        }

        public async Task<List<GetProjectsItemViewModel>> ExecuteAsync()
        {
            Int64 userId = this.authContext.CurrentUser.Id;

            return await dataContext
                .Projects
                .Where(x => x.IsDeleted == false && x.ProjectAdministrators.Any(a => a.UserId == userId))
                .ProjectTo<GetProjectsItemViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
