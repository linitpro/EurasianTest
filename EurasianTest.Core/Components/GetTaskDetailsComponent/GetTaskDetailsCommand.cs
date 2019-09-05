using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.Core.Components.GetTaskDetailsComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.GetTaskDetailsComponent
{
    public class GetTaskDetailsCommand : ICommand<Int64, GetTaskDetailsViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly UnitOfWork unitOfWork;

        public GetTaskDetailsCommand(DataContext dataContext
            , IMapper mapper
            , UnitOfWork unitOfWork
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
            this.unitOfWork = unitOfWork ?? throw new NotImplementedException(nameof(UnitOfWork));
        }

        public async Task<GetTaskDetailsViewModel> ExecuteAsync(Int64 request)
        {
            // получаем таску
            var result = await this.dataContext
                .Tasks
                .Where(x => x.Id == request && x.IsDeleted == false)
                .ProjectTo<GetTaskDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            // получаем список пользователей
            // TODO чтонибудь придумать, т.к. не очень красиво дергать команду из команды
            var command = this.unitOfWork.Create<GetUsersDictionaryCommand>(); 
            result.Users = await command.ExecuteAsync(new GetUsersDictionaryRequestViewModel());

            return result;
        }
    }
}
