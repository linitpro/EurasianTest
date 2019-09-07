using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetProjectDetailsComponent.Models;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetProjectDetailsStrategy.Implementations
{
    public class AdministratorGetProjectDetailsQuery : IGetProjectDetailsQuery
    {
        public Role Role
        {
            get
            {
                return Role.Administrator;
            }
        }

        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public AdministratorGetProjectDetailsQuery(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<GetProjectDetailsViewModel> ExecuteAsync(Int64 id)
        {
            var project = await this.dataContext
                .Projects
                .Where(x => x.IsDeleted == false && x.Id == id)
                .ProjectTo<GetProjectDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            project.AddedUsers = await this.dataContext
                .Users
                .Include(x => x.Projects)
                .Where(x => x.IsDeleted == false
                            && x.Projects.Any(a => a.IsDeleted == false && a.ProjectId == id)
                            && x.Role != Role.Administrator)
                .ProjectTo<GetProjectDetailsUserViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            project.Users = await this.dataContext
                .Users
                .Where(x => x.IsDeleted == false
                            && !x.Projects.Any(a => a.IsDeleted == false && a.ProjectId == id)
                            && x.Role != Role.Administrator)
                .ProjectTo<GetProjectDetailsUserViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return project;
        }
    }
}
