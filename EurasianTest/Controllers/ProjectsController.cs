using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EurasianTest.Code.ValidationHelper;
using EurasianTest.Core.Components.AddProjectAdministratorComponent;
using EurasianTest.Core.Components.AddProjectAdministratorComponent.Models;
using EurasianTest.Core.Components.AddProjectComponent;
using EurasianTest.Core.Components.AddProjectComponent.Model;
using EurasianTest.Core.Components.DeleteProjectComponent;
using EurasianTest.Core.Components.DeleteProjectComponent.Models;
using EurasianTest.Core.Components.GetProjectDetailsComponent;
using EurasianTest.Core.Components.GetProjectsComponent;
using EurasianTest.Core.Components.UpdateProjectComponent;
using EurasianTest.Core.Components.UpdateProjectComponent.Models;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EurasianTest.Controllers
{
    /// <summary>
    /// Контроллер для работы с проектами
    /// </summary>
    [Authorize]
    [Route("[controller]")]
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
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> Index()
        {
            var command = this.unitOfWork.Create<GetProjectsCommand>();

            return View(await command.ExecuteAsync(new Core.Components.GetProjectsComponent.Models.GetProjectsViewModel()));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Add()
        {
            return View(new AddProjectViewModel());
        }

        /// <summary>
        /// Добавляет новый проект
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddProjectViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var command = this.unitOfWork.Create<AddProjectCommand>();
            var response = await command.ExecuteAsync(model);
            return RedirectToAction("Index", "Projects");
        }

        /// <summary>
        /// Показывает детали проекта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpGet("[action]/{id}")]
        [ImportModelState]
        public async Task<IActionResult> Details([FromRoute]Int64 id)
        {
            var command = this.unitOfWork.Create<GetProjectDetailsCommand>();
            var result = await command.ExecuteAsync(id);
            return View(result);
        }

        /// <summary>
        /// Обновляет данные о проекте
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpPost("[action]")]
        [ExportModelState]
        public async Task<IActionResult> Update([FromForm]UpdateProjectViewModel model)
        {
            if(ModelState.IsValid)
            {
                var command = this.unitOfWork.Create<UpdateProjectCommand>();
                await command.ExecuteAsync(model);
            }
            else
            {

            }
            
            return Redirect($"/Projects/Details/{model.Id}");
        }

        /// <summary>
        /// Удаляет проект
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Delete([FromForm]DeleteProjectViewModel model)
        {
            var command = this.unitOfWork.Create<DeleteProjectCommand>();
            await command.ExecuteAsync(model);

            return Redirect("/Projects/Index");
        }

        /// <summary>
        /// Добавляет администратора проекта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpPost("[action]")]
        [ExportModelState]
        public async Task<IActionResult> AddProjectAdministrator([FromForm]AddProjectAdministratorViewModel model)
        {
            if(ModelState.IsValid)
            {
                var command = this.unitOfWork.Create<AddProjectAdministratorCommand>();
                await command.ExecuteAsync(model);
            }

            return Redirect($"/Projects/Details/{model.Id}");
        }
    }
}