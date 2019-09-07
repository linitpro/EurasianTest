using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetTasksStrategy.Implementations
{
    public class AdministratorGetTasksQuery : IGetTasksQuery
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

        public AdministratorGetTasksQuery(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<List<GetTasksItemViewModel>> ExecuteAsync()
        {
            return await dataContext
                .Tasks
                .Where(x => x.IsDeleted == false)
                .ProjectTo<GetTasksItemViewModel>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
