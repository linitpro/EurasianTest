using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.UpdateTaskComponent
{
    public class UpdateTaskCommand: ICommand<UpdateTaskViewModel, UpdateTaskViewModel>
    {
        private readonly DataContext dataContext;

        public UpdateTaskCommand(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public System.Threading.Tasks.Task<UpdateTaskViewModel> ExecuteAsync(UpdateTaskViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
