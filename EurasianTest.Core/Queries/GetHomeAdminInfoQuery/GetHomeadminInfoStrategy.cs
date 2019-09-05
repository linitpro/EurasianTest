using EurasianTest.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EurasianTest.Core.Queries.GetHomeAdminInfoQuery
{
    public class GetHomeadminInfoStrategy
    {
        private readonly IEnumerable<IGetHomeadminInfoQuery> queries;
        private readonly IAuthContext authContext;

        public GetHomeadminInfoStrategy(IEnumerable<IGetHomeadminInfoQuery> queries
            , IAuthContext authContext

            )
        {
            this.authContext = authContext ?? throw new NotImplementedException(nameof(IAuthContext));
            this.queries = queries ?? throw new NotImplementedException(nameof(IEnumerable<IGetHomeadminInfoQuery>));
        }

        public IGetHomeadminInfoQuery Query
        {
            get
            {
                return this.queries.FirstOrDefault(x => x.Role == this.authContext.CurrentUser.Role)
                    ?? throw new NotImplementedException($"{nameof(IGetHomeadminInfoQuery)} for role {this.authContext.CurrentUser.Role}");
            }
        }
    }
}
