using EurasianTest.Core.Components.GetProjectDetailsComponent.Models;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Queries.GetProjectDetailsStrategy
{
    public interface IGetProjectDetailsQuery
    {
        Role Role { get; }

        Task<GetProjectDetailsViewModel> ExecuteAsync(Int64 id);
    }
}
