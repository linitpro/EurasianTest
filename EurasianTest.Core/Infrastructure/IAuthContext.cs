using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Infrastructure
{
    public interface IAuthContext
    {
        User CurrentUser { get; }
    }
}
