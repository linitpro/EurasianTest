using AutoMapper;
using EurasianTest.Core.Components.GetProjectDetailsComponent.Models;
using EurasianTest.Core.Infrastructure;
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

        public GetProjectDetailsCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public Task<GetProjectDetailsViewModel> ExecuteAsync(Int64 request)
        {
            // получаем детали проекта 
            // и его администраторов

            throw new NotImplementedException();
        }
    }
}
