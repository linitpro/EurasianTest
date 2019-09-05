using EurasianTest.Core.Components.GetHomeInfoModel.Model;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                return Role.Administrator;
            }
        }

        public async Task<GetHomeAdminInfoViewModel> ExecuteAsync()
        {
            GetHomeAdminInfoViewModel result = null;

            // тот же запрос, что и у даминистратора, но ограничить совими проектами

            return result;
        }
    }
}
