using EurasianTest.Core.Components.AuthorizationComponent;
using EurasianTest.Core.Components.AuthorizationComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EurasianTest.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public AuthorizationController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View(new AuthorizationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(AuthorizationViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var command = this.unitOfWork.Create<AuthorizationCommand>();
            var user = await command.ExecuteAsync(model);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // установка аутентификационных кук
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id),
                new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24),
                    AllowRefresh = model.RememberMe,
                    IsPersistent = model.RememberMe
                });

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Authorization/Index");
        }
    }
}
