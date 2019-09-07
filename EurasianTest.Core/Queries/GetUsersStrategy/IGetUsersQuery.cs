using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Queries.GetUsersStrategy
{
    public interface IGetUsersQuery
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
        Task<List<UserViewModel>> ExecuteAsync();
    }
}
