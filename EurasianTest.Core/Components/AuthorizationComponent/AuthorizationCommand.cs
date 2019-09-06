using EurasianTest.Core.Components.AuthorizationComponent.Models;
using EurasianTest.Core.Factories;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.AuthorizationComponent
{
    public class AuthorizationCommand : ICommand<AuthorizationViewModel, User>
    {
        private readonly DataContext dataContext;

        public AuthorizationCommand(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
        }

        public async Task<User> ExecuteAsync(AuthorizationViewModel request)
        {
            var user = await this.dataContext.Users.FirstOrDefaultAsync(x => x.Email == request.Login);

            if (user == null)
            {
                throw new CoreException(ResultCode.UserAlreadyExist);
            }

            if (user.Password != SecurityFactory.HashPassword(request.Password, user.Salt))
            {
                throw new CoreException(ResultCode.UserIncorrectPassword);
            }

            return user;
        }
    }
}
