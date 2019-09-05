using EurasianTest.Core.Components.GetHomeInfoModel.Model;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Queries.GetHomeAdminInfoQuery
{
    public interface IGetHomeadminInfoQuery
    {
        Role Role { get; }

        Task<GetHomeAdminInfoViewModel> ExecuteAsync();
    }
}
