using AutoMapper;
using EurasianTest.Core.Components.UpdateTaskComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.UpdateTaskComponent
{
    public class UpdateTaskCommand: ICommand<UpdateTaskViewModel, UpdateTaskViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public UpdateTaskCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async System.Threading.Tasks.Task<UpdateTaskViewModel> ExecuteAsync(UpdateTaskViewModel request)
        {
            var task = await this.dataContext.Tasks.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == request.Id);

            if(task == null)
            {
                throw new CoreException(ResultCode.TasksNotFound);
            }

            task.Name = request.Name;
            task.Description = request.Description;
            task.Started = request.Started;
            task.Expired = request.Expired;

            this.dataContext.Tasks.Update(task);
            await this.dataContext.SaveChangesAsync();

            return request;
        }
    }
}
