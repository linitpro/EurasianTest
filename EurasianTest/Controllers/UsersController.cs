using System;
using System.Threading.Tasks;
using EurasianTest.Core.Components.ChangeUserRoleComponent;
using EurasianTest.Core.Components.ChangeUserRoleComponent.Models;
using EurasianTest.Core.Components.GetUserDetailsComponent;
using EurasianTest.Core.Components.GetUsersComponent;
using EurasianTest.Core.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EurasianTest.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public UsersController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<IActionResult> Index()
        {
            var command = this.unitOfWork.Create<GetUsersCommand>();
            return View(await command.ExecuteAsync(new Core.Components.GetUsersComponent.Models.GetUsersViewModel()));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Details([FromRoute]Int64 id)
        {
            var command = this.unitOfWork.Create<GetUserDetailsCommand>();
            return View(await command.ExecuteAsync(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeRole([FromForm]ChangeUserRoleViewModel model)
        {
            var command = this.unitOfWork.Create<ChangeUserRoleCommand>();
            await command.ExecuteAsync(model);

            return Redirect($"/Users/Details/{model.Id}");
        }
    }
}