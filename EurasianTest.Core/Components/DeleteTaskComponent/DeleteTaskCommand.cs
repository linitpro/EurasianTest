using AutoMapper;
using EurasianTest.Core.Components.DeleteTaskComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.DeleteTaskComponent
{
    public class DeleteTaskCommand : ICommand<DeleteTaskViewModel, DeleteTaskViewModel>
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public DeleteTaskCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<DeleteTaskViewModel> ExecuteAsync(DeleteTaskViewModel request)
        {
            var task = await this.dataContext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(task == null)
            {
                return request;
            }

            task.IsDeleted = true;

            this.dataContext.Update(task);
            await this.dataContext.SaveChangesAsync();

            return request;
        }
    }
}
