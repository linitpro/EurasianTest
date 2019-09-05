using AutoMapper;
using EurasianTest.Core.Components.DeleteProjectComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.DeleteProjectComponent
{
    public class DeleteProjectCommand: ICommand<DeleteProjectViewModel, DeleteProjectViewModel>
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public DeleteProjectCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<DeleteProjectViewModel> ExecuteAsync(DeleteProjectViewModel request)
        {
            var project = await this.dataContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id);

            if(project == null)
            {
                return request;
            }

            project.IsDeleted = true;

            this.dataContext.Update(project);
            await this.dataContext.SaveChangesAsync();

            return request;
        }
    }
}
