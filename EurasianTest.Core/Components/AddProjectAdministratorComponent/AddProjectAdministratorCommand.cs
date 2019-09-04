using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.AddProjectAdministratorComponent
{
    public class AddProjectAdministratorCommand : ICommand<AddProjectAdministratorViewModel, Int64>
    {
        private readonly DataContext dataContext;

        public AddProjectAdministratorCommand(DataContext dataContext
            
            )
        {
            this.dataContext = dataContext;
        }

        public Task<Int64> ExecuteAsync(AddProjectAdministratorViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
