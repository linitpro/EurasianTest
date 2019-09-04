using EurasianTest.Core.Infrastructure;
using EurasianTest.Core.Queries.GetProjectsStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EurasianTest.Core.Queries.GetProjectDetailsStrategy
{
    public class GetProjectDetailsStrategy
    {
        IEnumerable<IGetProjectDetailsQuery> queries;
        private readonly IAuthContext authContext;

        public GetProjectDetailsStrategy(IEnumerable<IGetProjectDetailsQuery> queries
            , IAuthContext authContext 
            
            )
        {
            this.queries = queries ?? throw new NotImplementedException(nameof(IEnumerable<IGetProjectDetailsQuery>));
            this.authContext = authContext ?? throw new NotImplementedException(nameof(IAuthContext));
        }

        public IGetProjectDetailsQuery Query
        {
            get
            {
                return this.queries.FirstOrDefault(x => x.Role == this.authContext.CurrentUser.Role);
            }
        }
    }
}
