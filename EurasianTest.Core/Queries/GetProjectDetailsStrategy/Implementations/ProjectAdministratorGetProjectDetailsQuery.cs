using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetProjectDetailsComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetProjectDetailsStrategy.Implementations
{
    public class ProjectAdministratorGetProjectDetailsQuery : IGetProjectDetailsQuery
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

        public ProjectAdministratorGetProjectDetailsQuery(DataContext dataContext
            , IMapper mapper
            , IAuthContext authContext
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.authContext = authContext;
        }

        public async Task<GetProjectDetailsViewModel> ExecuteAsync(Int64 projectId)
        {
            var project = await this.dataContext
                .Projects
                .Where(x => x.IsDeleted == false 
                            && x.Id == projectId 
                            && x.ProjectAdministrators.Any(a => a.UserId == this.authContext.CurrentUser.Id))
                .ProjectTo<GetProjectDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return project;
        }
    }
}
