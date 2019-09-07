using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetProjectsStrategy.Implementations
{
    public class AdministratorGetProjectsQuery : IGetProjectsQuery
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

        public AdministratorGetProjectsQuery(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<List<GetProjectsItemViewModel>> ExecuteAsync()
        {
            return await dataContext
                .Projects
                .Where(x => x.IsDeleted == false)
                .ProjectTo<GetProjectsItemViewModel>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
