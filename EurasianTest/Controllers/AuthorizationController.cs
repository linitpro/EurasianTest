using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EurasianTest.Controllers
{
    public class AuthorizationController: Controller
    {

        public async Task<IActionResult> Index()
        {


            return View();
        }
    }
}
