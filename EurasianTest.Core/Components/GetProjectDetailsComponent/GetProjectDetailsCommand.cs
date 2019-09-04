using AutoMapper;
using EurasianTest.Core.Components.GetProjectDetailsComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.Core.Queries.GetProjectDetailsStrategy;
using EurasianTest.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.GetProjectDetailsComponent
{
    public class GetProjectDetailsCommand : ICommand<Int64, GetProjectDetailsViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly GetProjectDetailsStrategy getProjectDetailsStrategy;

        public GetProjectDetailsCommand(DataContext dataContext
            , IMapper mapper
            , GetProjectDetailsStrategy getProjectDetailsStrategy
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.getProjectDetailsStrategy = getProjectDetailsStrategy;
        }

        public async Task<GetProjectDetailsViewModel> ExecuteAsync(Int64 request)
        {
            return await this.getProjectDetailsStrategy.Query.ExecuteAsync(request);
        }
    }
}
