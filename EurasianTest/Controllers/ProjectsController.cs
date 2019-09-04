using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EurasianTest.Core.Components.AddProjectComponent;
using EurasianTest.Core.Components.AddProjectComponent.Model;
using EurasianTest.Core.Components.GetProjectsComponent;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EurasianTest.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize] // TODO add role based auth
    public class ProjectsController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public ProjectsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Выводит на экран список проектов в которых участвует пользователь 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var command = this.unitOfWork.Create<GetProjectsCommand>();

            return View(await command.ExecuteAsync(new Core.Components.GetProjectsComponent.Models.GetProjectsViewModel()));
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Add()
        {
            return View(new AddProjectViewModel());
        }

        /// <summary>
        /// Добавляет новый проект
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Add(AddProjectViewModel model)
        {
            var command = this.unitOfWork.Create<AddProjectCommand>();
            var response = await command.ExecuteAsync(model);


            return RedirectToAction(nameof(ProjectsController.Details), response);
        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> Details([FromRoute]Int64 id)
        {
            return View();
        }
    }
}