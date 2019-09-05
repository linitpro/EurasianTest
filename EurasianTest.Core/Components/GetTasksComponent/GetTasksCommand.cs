using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.GetTasksComponent
{
    public class GetTasksCommand: ICommand<GetTasksViewModel, GetTasksViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public GetTasksCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<GetTasksViewModel> ExecuteAsync(GetTasksViewModel request)
        {
            request.Items = await this.dataContext
                .Tasks
                .Where(x => x.IsDeleted == false)
                .ProjectTo<GetTasksItemViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return request;
        }
    }
}
