using EurasianTest.Core.Components.UpdateProjectComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.UpdateProjectComponent
{
    public class UpdateProjectCommand : ICommand<UpdateProjectViewModel, Int64>
    {
        private readonly DataContext dataContext;

        public UpdateProjectCommand(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
        }

        public async Task<Int64> ExecuteAsync(UpdateProjectViewModel request)
        {
            var project = await this.dataContext
                .Projects
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);

            if(project == null)
            {
                throw new CoreException(ResultCode.ProjectNotFound);
            }

            project.Name = request.Name;

            this.dataContext.Projects.Update(project);
            await this.dataContext.SaveChangesAsync();

            return request.Id;
        }
    }
}
