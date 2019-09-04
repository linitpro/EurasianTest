﻿using EurasianTest.Core.Components.AuthorizationComponent.Models;
using EurasianTest.DAL.Entities.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EurasianTest.Controllers
{
    public class AuthorizationController: Controller
    {

        public async Task<IActionResult> Index()
        {
            return View(new AuthorizationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(AuthorizationViewModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Login), // TODO нужна команда авторизации
                new Claim(ClaimTypes.Role, Role.Administrator.ToString())
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
    }
}
