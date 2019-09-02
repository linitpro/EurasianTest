using EurasianTest.Core.Constants;
using EurasianTest.Core.Helpers;
using EurasianTest.DAL.Entities.Enums;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Factories
{
    public static class UserFactory
    {
        public static User Create(String email, String password)
        {
            var credetial = SecurityFactory.CreateCredetial(password);
            return new User()
            {
                IsDeleted = false,
                Created = DateTime.Now,
                Email = email,
                Salt = credetial.Salt,
                Role = Role.ProjectAdministrator,
                Password = credetial.HashedPassword
            };
        }
    }
}
