using EurasianTest.Core.Components.AuthorizationComponent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EurasianTest.Code.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<IActionResult> Authorize(AuthorizationViewModel authorizationViewModel);
    }
}
