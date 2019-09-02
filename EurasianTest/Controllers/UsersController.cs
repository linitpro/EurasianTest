using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EurasianTest.Core.Components.GetUsersComponent;
using EurasianTest.Core.Components.OuterRegistrationComponent;
using EurasianTest.Core.Components.OuterRegistrationComponent.Models;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EurasianTest.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public UsersController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var command = this.unitOfWork.Create<GetUsersCommand>();
            return View(await command.ExecuteAsync(new Core.Components.GetUsersComponent.Models.GetUsersViewModel()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute]Int64 id)
        {
            return View();
        }
    }
}