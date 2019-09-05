using EurasianTest.Core.Components.GetHomeInfoModel.Model;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Queries.GetHomeAdminInfoQuery.Implementations
{
    class UserGetHomeadminInfoQuery : IGetHomeadminInfoQuery
    {
        public UserGetHomeadminInfoQuery() { }

        public Role Role
        {
            get
            {
                return Role.Administrator;
            }
        }

        public Task<GetHomeAdminInfoViewModel> ExecuteAsync()
        {
            // у пользователя не должно быть такой информации
            return null;
        }
    }
}
