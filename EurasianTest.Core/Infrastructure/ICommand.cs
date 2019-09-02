using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Infrastructure
{
    public interface ICommand { }

    public interface ICommand<TRequest, TResponse>: ICommand
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
