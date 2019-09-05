using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.GetUserDetailsComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.GetUserDetailsComponent
{
    public class GetUserDetailsCommand : ICommand<Int64, GetUserDetailsViewModel>
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public GetUserDetailsCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<GetUserDetailsViewModel> ExecuteAsync(Int64 request)
        {
            var result = await this.dataContext
                .Users
                .Where(x => x.IsDeleted == false && x.Id == request)
                .ProjectTo<GetUserDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if(result == null)
            {
                throw new CoreException(ResultCode.UserNotFound);
            }

            return result;
        }
    }
}
