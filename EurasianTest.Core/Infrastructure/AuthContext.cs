using EurasianTest.DAL.Entities.Enums;
using EurasianTest.DAL.Entities.Implementations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EurasianTest.Core.Infrastructure
{
    public class AuthContext: IAuthContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public User CurrentUser
        {
            get
            {
                return new User()
                {
                    Role = (Role)Enum.Parse(typeof(Role), httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? "User")
                };
            }
        }
    }
}
