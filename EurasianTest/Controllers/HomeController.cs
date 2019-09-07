using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EurasianTest.Models;
using Microsoft.AspNetCore.Authorization;
using EurasianTest.Core.Infrastructure;
using EurasianTest.Core.Components.GetHomeInfoModel;

namespace EurasianTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var command = this.unitOfWork.Create<GetHomeInfoCommand>();

            return View(await command.ExecuteAsync());
        }

    }
}
