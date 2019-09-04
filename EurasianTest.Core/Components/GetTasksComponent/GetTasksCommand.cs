using EurasianTest.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetTasksComponent
{
    public class GetTasksCommand
    {
        private readonly DataContext dataContext;

        public GetTasksCommand(DataContext dataContext
            
            )
        {
            this.dataContext = dataContext;
        }

    }
}
