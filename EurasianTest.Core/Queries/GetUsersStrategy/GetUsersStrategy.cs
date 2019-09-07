using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EurasianTest.Core.Queries.GetUsersStrategy
{
    public class GetUsersStrategy
    {
        IEnumerable<IGetUsersQuery> queries;
        private readonly IAuthContext authContext;

        public GetUsersStrategy(IEnumerable<IGetUsersQuery> queries, IAuthContext authContext)
        {
            this.queries = queries;
            this.authContext = authContext;
        }

        /// <summary>
        /// Возвращает подходящую реализацию для получения списка проектов
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public IGetUsersQuery Query
        {
            get
            {
                return this.queries.FirstOrDefault(x => x.Role == this.authContext.CurrentUser.Role);
            }
        }
    }
}
