using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.DictionaryComponents.GetTasksDictionaryComponent.Models;
using EurasianTest.Core.Components.GetHomeInfoModel.Model;
using EurasianTest.Core.Infrastructure;
using EurasianTest.Core.Queries.GetHomeAdminInfoQuery;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.GetHomeInfoModel
{
    public class GetHomeInfoCommand: ICommand<GetHomeInfoViewModel>
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;
        private readonly IAuthContext authContext;
        private readonly GetHomeadminInfoStrategy strategy;

        public GetHomeInfoCommand(DataContext dataContext
            , IMapper mapper
            , IAuthContext authContext
            , GetHomeadminInfoStrategy strategy
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.authContext = authContext;
            this.strategy = strategy;
        }

        public async Task<GetHomeInfoViewModel> ExecuteAsync()
        {
            var model = new GetHomeInfoViewModel();

            var admInfoTask = strategy.Query.ExecuteAsync();
            var currentTask = this.dataContext
                .Tasks
                .Where(x => x.UserId == this.authContext.CurrentUser.Id 
                            && x.Status == DAL.Entities.Enums.TaskStatus.Working
                            && x.IsDeleted == false)
                .ProjectTo<TaskViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
            var nextWeekTask = this.dataContext
                .GetTasksQuery
                .FromSql($@"
                    SELECT ""Id"", ""Name"" FROM public.""Tasks"" 
                    WHERE EXTRACT(WEEK FROM ""Started"") = EXTRACT(WEEK FROM (NOW() + INTERVAL '7 day'))
                        AND ""UserId"" = {this.authContext.CurrentUser.Id}
                        AND ""IsDeleted"" = false;
                ")
                .ToListAsync();

            Task.WaitAll(admInfoTask, currentTask, nextWeekTask);

            model.AdminInfo = admInfoTask.Result;
            model.TaskForWork = currentTask.Result;
            model.TasksStartOnNextWeek = nextWeekTask.Result.Select(x => new TaskViewModel() { Id = x.Id, Name = x.Name }).ToList();

            return model;
        }
    }
}
