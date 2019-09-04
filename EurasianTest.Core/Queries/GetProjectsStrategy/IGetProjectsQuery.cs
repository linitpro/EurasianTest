using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Queries.GetProjectsStrategy
{
    public interface IGetProjectsQuery
    {
        /// <summary>
        /// Роль пользователя, который запрашивает проекты
        /// на основе нее будем определять, что нужно отдавать
        /// </summary>
        Role Role { get; }

        /// <summary>
        /// Выполняет запрос
        /// </summary>
        /// <returns></returns>
        Task<List<GetProjectsItemViewModel>> ExecuteAsync();
    }
}
