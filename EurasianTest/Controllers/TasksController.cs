using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EurasianTest.Code.ValidationHelper;
using EurasianTest.Core.Components.AddTaskComponent;
using EurasianTest.Core.Components.AddTaskComponent.Models;
using EurasianTest.Core.Components.ChangeTaskStatusComponent;
using EurasianTest.Core.Components.ChangeTaskStatusComponent.Models;
using EurasianTest.Core.Components.DeleteTaskComponent;
using EurasianTest.Core.Components.DeleteTaskComponent.Models;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.Core.Components.GetProjectDetailsComponent;
using EurasianTest.Core.Components.GetTaskDetailsComponent;
using EurasianTest.Core.Components.GetTasksComponent;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.Core.Components.UpdateTaskComponent;
using EurasianTest.Core.Components.UpdateTaskComponent.Models;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EurasianTest.Controllers
{
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public TasksController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new NotImplementedException(nameof(UnitOfWork));
        }

        /// <summary>
        /// Отображает список задач пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> Index([FromQuery]GetTasksViewModel model)
        {
            var command = this.unitOfWork.Create<GetTasksCommand>();
            
            if(model == null)
            {
                model = new GetTasksViewModel();
            }
            model = await command.ExecuteAsync(model);

            return View(model);
        }

        /// <summary>
        /// Показывает страницу добавления новой задачи к проекту
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator,ProjectAdministrator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Add([FromQuery]Int64 projectId)
        {
            var model = new AddTaskViewModel();
            var userCommandResult = this.unitOfWork.Create<GetUsersDictionaryCommand>().ExecuteAsync(new GetUsersDictionaryRequestViewModel() { ProjectId = projectId });
            var projectCommandResult = this.unitOfWork.Create<GetProjectDetailsCommand>().ExecuteAsync(projectId);
            Task.WaitAll(userCommandResult, projectCommandResult);
            model.ProjectName = projectCommandResult.Result.Name;
            model.Users = userCommandResult.Result;

            return View(model);
        }

        /// <summary>
        /// Добавляет новую задачу
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator,ProjectAdministrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromForm]AddTaskViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var command = this.unitOfWork.Create<AddTaskCommand>();
            var result = await command.ExecuteAsync(model);

            return Redirect($"/Tasks/Details/{result}");
        }

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        /// <returns></returns>
        [ExportModelState]
        [Authorize(Roles = "Administrator,ProjectAdministrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromForm]UpdateTaskViewModel model)
        {
            if(ModelState.IsValid)
            {
                TempData["ModelState"] = null;
                var command = this.unitOfWork.Create<UpdateTaskCommand>();
                var result = await command.ExecuteAsync(model);
            }

            return Redirect($"/Tasks/Details/{model.Id}");
        }

        /// <summary>
        /// Редактирование статуса и ответственного задачи
        /// </summary>
        /// <returns></returns>
        [ExportModelState]
        [Authorize(Roles = "Administrator,ProjectAdministrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateStatus([FromForm]ChangeTaskStatusViewModel model)
        {
            var command = this.unitOfWork.Create<ChangeTaskStatusCommand>();
            var result = await command.ExecuteAsync(model);
            return Redirect($"/Tasks/Details/{model.Id}");
        }

        /// <summary>
        /// Показывает детали задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ImportModelState]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Details([FromRoute]Int64 id)
        {
            var command = this.unitOfWork.Create<GetTaskDetailsCommand>();
            var result = await command.ExecuteAsync(id);
            return View(result);
        }

        /// <summary>
        /// Удаляет задачу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator,ProjectAdministrator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Delete([FromForm]Int64 id)
        {
            var command = this.unitOfWork.Create<DeleteTaskCommand>();
            var result = await command.ExecuteAsync(new DeleteTaskViewModel() { Id = id });
            return Redirect("/Tasks/Index");
        }
    }
}