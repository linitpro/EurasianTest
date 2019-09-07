using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EurasianTest.Core.Queries.GetTasksStrategy
{
    public class GetTasksStrategy
    {
        IEnumerable<IGetTasksQuery> queries;
        private readonly IAuthContext authContext;

        public GetTasksStrategy(IEnumerable<IGetTasksQuery> queries, IAuthContext authContext)
        {
            this.queries = queries;
            this.authContext = authContext;
        }

        /// <summary>
        /// Возвращает подходящую реализацию для получения списка проектов
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public IGetTasksQuery Query
        {
            get
            {
                return this.queries.FirstOrDefault(x => x.Role == this.authContext.CurrentUser.Role);
            }
        }
    }
}
