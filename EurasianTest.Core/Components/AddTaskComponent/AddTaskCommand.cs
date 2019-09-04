using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddTaskComponent
{
    public class AddTaskCommand: ICommand<AddTaskViewModel, AddTaskViewModel>
    {
        private readonly DataContext dataContext;

        public AddTaskCommand(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public System.Threading.Tasks.Task<AddTaskViewModel> ExecuteAsync(AddTaskViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
