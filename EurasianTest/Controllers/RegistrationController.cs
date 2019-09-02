using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EurasianTest.Controllers
{
    public class RegistrationController : Controller
    {
        public async  Task<IActionResult> Index()
        {


            return View();
        }
    }
}