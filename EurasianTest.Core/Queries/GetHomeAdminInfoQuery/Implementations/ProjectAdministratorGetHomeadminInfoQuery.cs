using EurasianTest.Core.Components.GetHomeInfoModel.Model;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Queries.GetHomeAdminInfoQuery.Implementations
{
    public class ProjectAdministratorGetHomeadminInfoQuery : IGetHomeadminInfoQuery
    {
        private readonly DataContext dataContext;

        public ProjectAdministratorGetHomeadminInfoQuery(DataContext dataContext

            )
        {
            this.dataContext = dataContext;
        }

        public Role Role
        {
            get
            {
                return Role.ProjectAdministrator;
            }
        }

        public async System.Threading.Tasks.Task<GetHomeAdminInfoViewModel> ExecuteAsync()
        {
            return null;
        }
    }
}
