using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EurasianTest.Core.Queries.GetProjectsStrategy
{
    public class GetProjectsStrategy
    {
        IEnumerable<IGetProjectsQuery> queries;
        private readonly IAuthContext authContext;

        public GetProjectsStrategy(IEnumerable<IGetProjectsQuery> queries, IAuthContext authContext)
        {
            this.queries = queries;
            this.authContext = authContext;
        }

        /// <summary>
        /// Возвращает подходящую реализацию для получения списка проектов
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public IGetProjectsQuery Query
        {
            get
            {
                return this.queries.FirstOrDefault(x => x.Role == this.authContext.CurrentUser.Role);
            }
        }
    }
}
