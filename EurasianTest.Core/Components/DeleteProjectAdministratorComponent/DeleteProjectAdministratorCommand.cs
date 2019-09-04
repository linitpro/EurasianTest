using EurasianTest.Core.Components.DeleteProjectAdministratorComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.DeleteProjectAdministratorComponent
{
    public class DeleteProjectAdministratorCommand : ICommand<DeleteProjectAdministratorViewModel, Int64>
    {
        private readonly DataContext dataContext;

        public DeleteProjectAdministratorCommand(DataContext dataContext
            
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(dataContext));
        }

        public Task<long> ExecuteAsync(DeleteProjectAdministratorViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
