using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Infrastructure
{
    public class UnitOfWork
    {
        private readonly IServiceProvider serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TCommand Create<TCommand>()
            where TCommand: ICommand
        {
            return (TCommand)this.serviceProvider.GetService(typeof(TCommand));
        }
    }
}
