using EurasianTest.Core.Components.AddProjectAdministratorComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.AddProjectAdministratorComponent
{
    public class AddProjectAdministratorCommand : ICommand<AddProjectAdministratorViewModel, Int64>
    {
        private readonly DataContext dataContext;

        public AddProjectAdministratorCommand(DataContext dataContext
            
            )
        {
            this.dataContext = dataContext;
        }

        public async Task<Int64> ExecuteAsync(AddProjectAdministratorViewModel request)
        {
            // проверим, существует ли такой администратор
            var projectAdmin = await this.dataContext
                .ProjectAdministrators
                .FirstOrDefaultAsync(x => x.ProjectId == request.Id && x.UserId == request.UserId);

            // добавим нового
            if (projectAdmin == null)
            {
                projectAdmin = new ProjectAdministrator(request.UserId, request.Id);
                await this.dataContext.AddAsync(projectAdmin);
                await this.dataContext.SaveChangesAsync();
            }
            else
            {
                // если существует и удален - оживим
                if(projectAdmin.IsDeleted)
                {
                    projectAdmin.IsDeleted = false;
                    this.dataContext.Update(projectAdmin);
                    await this.dataContext.SaveChangesAsync();
                } // если существует и не удален - вернем
                else
                {
                    return projectAdmin.Id;
                }

            }

            return projectAdmin.Id;
        }
    }
}
