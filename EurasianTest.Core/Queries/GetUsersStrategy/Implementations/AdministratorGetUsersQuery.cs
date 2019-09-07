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
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EurasianTest.Core.Queries.GetUsersStrategy.Implementations
{
    public class AdministratorGetUsersQuery : IGetUsersQuery
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

        public AdministratorGetUsersQuery(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<List<UserViewModel>> ExecuteAsync()
        {
            return await dataContext
                .Users
                .Where(x => x.IsDeleted == false)
                .ProjectTo<UserViewModel>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.Email)
                .ToListAsync();
        }
    }
}
