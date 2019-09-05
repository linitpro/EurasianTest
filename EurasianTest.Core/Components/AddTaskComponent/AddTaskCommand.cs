using AutoMapper;
using EurasianTest.Core.Components.AddTaskComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddTaskComponent
{
    public class AddTaskCommand: ICommand<AddTaskViewModel, Int64>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;


        public AddTaskCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async System.Threading.Tasks.Task<Int64> ExecuteAsync(AddTaskViewModel request)
        {
            var newTask = this.mapper.Map<Task>(request);
            await this.dataContext.AddAsync(newTask);
            await this.dataContext.SaveChangesAsync();
            return newTask.Id;
        }
    }
}
