using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            return View();
        }

        
    }
}