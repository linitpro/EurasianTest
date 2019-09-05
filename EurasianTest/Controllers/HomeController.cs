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

        public async Task<IActionResult> Index()
        {
            var command = this.unitOfWork.Create<GetHomeInfoCommand>();

            return View(await command.ExecuteAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
