using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EurasianTest.Code.Services.Interfaces;
using EurasianTest.Core.Components.AuthorizationComponent;
using EurasianTest.Core.Components.AuthorizationComponent.Models;
using EurasianTest.Core.Components.OuterRegistrationComponent;
using EurasianTest.Core.Components.OuterRegistrationComponent.Models;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EurasianTest.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IAuthorizationService authorizationService;

        public RegistrationController(UnitOfWork unitOfWork
            , IAuthorizationService authorizationService)
        {
            this.unitOfWork = unitOfWork ?? throw new NotImplementedException(nameof(UnitOfWork));
            this.authorizationService = authorizationService ?? throw new NotImplementedException(nameof(IAuthorizationService));
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(new OuterRegistrationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(OuterRegistrationViewModel model)
        {
            var registerCommand = this.unitOfWork.Create<OuterRegistrationCommand>();
            await registerCommand.ExecuteAsync(model);

            return RedirectToAction("Index", "Authorization");
        }
    }
}