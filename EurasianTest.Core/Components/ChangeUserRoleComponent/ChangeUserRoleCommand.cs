using AutoMapper;
using EurasianTest.Core.Components.ChangeUserRoleComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.ChangeUserRoleComponent
{
    public class ChangeUserRoleCommand: ICommand<ChangeUserRoleViewModel, ChangeUserRoleViewModel>
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public ChangeUserRoleCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<ChangeUserRoleViewModel> ExecuteAsync(ChangeUserRoleViewModel model)
        {
            var user = await this.dataContext.Users.FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == model.Id);

            if (user == null)
            {
                throw new CoreException(ResultCode.UserNotFound);
            }

            user.Role = model.Role;

            this.dataContext.Update(user);
            await this.dataContext.SaveChangesAsync();

            return model;
        }
    }
}
