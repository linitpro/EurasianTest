using AutoMapper;
using EurasianTest.Core.Components.AddProjectComponent.Model;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.AddProjectComponent
{
    public class AddProjectCommand: ICommand<AddProjectViewModel, Int64>
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public AddProjectCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<Int64> ExecuteAsync(AddProjectViewModel request)
        {
            var project = this.mapper.Map<Project>(request);

            await this.dataContext.AddAsync(project);
            await this.dataContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
