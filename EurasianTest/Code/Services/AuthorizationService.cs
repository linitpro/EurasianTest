using EurasianTest.Code.Services.Interfaces;
using EurasianTest.Core.Components.AuthorizationComponent;
using EurasianTest.Core.Components.AuthorizationComponent.Models;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EurasianTest.Code.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UnitOfWork unitOfWork;

        public AuthorizationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Authorize(AuthorizationViewModel authorizationViewModel)
        {
            var command = this.unitOfWork.Create<AuthorizationCommand>();
            await command.ExecuteAsync(authorizationViewModel);

            

            return new RedirectToActionResult("Index", "Home", null);
        }
    }
}
