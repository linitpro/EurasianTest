using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetUsersComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.GetUsersComponent
{
    public class GetUsersCommand : ICommand<GetUsersViewModel, GetUsersViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public GetUsersCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<GetUsersViewModel> ExecuteAsync(GetUsersViewModel request)
        {
            request.Users = await this.dataContext
                .Users
                .Where(x => x.IsDeleted == false)
                .ProjectTo<GetUsersItemViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return request;
        }
    }
}
