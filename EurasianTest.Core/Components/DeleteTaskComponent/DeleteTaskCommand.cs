using EurasianTest.Core.Components.DeleteTaskComponent.Models;
using EurasianTest.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.DeleteTaskComponent
{
    public class DeleteTaskCommand : ICommand<DeleteTaskViewModel, DeleteTaskViewModel>
    {

        public DeleteTaskCommand()
        {

        }

        public async Task<DeleteTaskViewModel> ExecuteAsync(DeleteTaskViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
