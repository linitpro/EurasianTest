using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EurasianTest.Core.Components.AddTaskComponent;
using EurasianTest.Core.Components.AddTaskComponent.Models;
using EurasianTest.Core.Components.ChangeTaskStatusComponent;
using EurasianTest.Core.Components.ChangeTaskStatusComponent.Models;
using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent;
using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.Core.Components.GetTaskDetailsComponent;
using EurasianTest.Core.Components.GetTasksComponent;
using EurasianTest.Core.Components.GetTasksComponent.Models;
using EurasianTest.Core.Components.UpdateTaskComponent;
using EurasianTest.Core.Components.UpdateTaskComponent.Models;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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
        /// Отображает всписок задач пользователя
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

            return View(await command.ExecuteAsync(model));
        }

        /// <summary>
        /// Показывает страницу добавления новой задачи
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> Add() // TODO перегрузить для возможности добавить к пользователю или проекту
        {
            var model = new AddTaskViewModel();
            var userCommandResult = this.unitOfWork.Create<GetUsersDictionaryCommand>().ExecuteAsync(new GetUsersDictionaryRequestViewModel());
            var projectCommandResult = this.unitOfWork.Create<GetProjectsDictionaryCommand>().ExecuteAsync(new GetProjectsDictionaryRequestViewModel());
            Task.WaitAll(userCommandResult, projectCommandResult);
            model.Projects = projectCommandResult.Result;
            model.Users = userCommandResult.Result;

            return View(model);
        }

        /// <summary>
        /// Добавляет новую задачу
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromForm]AddTaskViewModel model)
        {
            var command = this.unitOfWork.Create<AddTaskCommand>();
            var result = await command.ExecuteAsync(model);

            return Redirect($"/Tasks/Details/{result}");
        }

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> Update([FromForm]UpdateTaskViewModel model)
        {
            var command = this.unitOfWork.Create<UpdateTaskCommand>();
            var result = await command.ExecuteAsync(model);

            return Redirect($"/Tasks/Details/{model.Id}");
        }

        /// <summary>
        /// Редактирование статуса и ответственного задачи
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> UpdateStatus([FromForm]ChangeTaskStatusViewModel model)
        {
            var command = this.unitOfWork.Create<ChangeTaskStatusCommand>();
            var result = await command.ExecuteAsync(model);
            return Redirect($"/Tasks/Details/{model.Id}");
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Details([FromRoute]Int64 id)
        {
            var command = this.unitOfWork.Create<GetTaskDetailsCommand>();
            var result = await command.ExecuteAsync(id);
            return View(result);
        }
    }
}