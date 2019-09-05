using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EurasianTest.Core.Components.AddTaskComponent.Models;
using EurasianTest.Core.Components.GetTasksComponent.Models;
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
        public async Task<IActionResult> Index()
        {


            return View(new GetTasksViewModel());
        }

        /// <summary>
        /// Показывает страницу добавления новой задачи
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> Add() // TODO перегрузить для возможности добавить к пользователю или проекту
        {
            return View(new AddTaskViewModel());
        }

        /// <summary>
        /// Добавляет новую задачу
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromForm]AddTaskViewModel model)
        {


            return View();
        }

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IActionResult> Update()
        {
            return View(new UpdateTaskViewModel());
        }

        /// <summary>
        /// Редактирование задачи
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("[action]")] // TODO ограничение по ролям: админы
        public async Task<IActionResult> Update([FromForm]UpdateTaskViewModel model)
        {
            return Redirect($"/Tasks/Details/{model.Id}");
        }
    }
}