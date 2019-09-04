using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EurasianTest.Controllers
{
    public class TasksController : Controller
    {
        /// <summary>
        /// Отображает всписок задач пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}