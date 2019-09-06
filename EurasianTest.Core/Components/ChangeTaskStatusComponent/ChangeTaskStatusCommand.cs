using AutoMapper;
using EurasianTest.Core.Components.ChangeTaskStatusComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.ChangeTaskStatusComponent
{
    public class ChangeTaskStatusCommand: ICommand<ChangeTaskStatusViewModel, ChangeTaskStatusViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IAuthContext authContext;

        public ChangeTaskStatusCommand(DataContext dataContext
            , IMapper mapper
            , IAuthContext authContext
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
            this.authContext = authContext ?? throw new NotImplementedException(nameof(IAuthContext));
        }

        public async Task<ChangeTaskStatusViewModel> ExecuteAsync(ChangeTaskStatusViewModel request)
        {
            using (var transaction = await this.dataContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var oldData = await this.dataContext.Tasks.Where(x => x.Id == request.Id && x.IsDeleted == false).FirstOrDefaultAsync();

                    if (oldData == null)
                    {
                        throw new CoreException(ResultCode.TasksNotFound);
                    }

                    // записываем исторические данные
                    var history = new TaskHistory(oldData, request.Status, this.authContext.CurrentUser.Id, request.UserId);
                    await this.dataContext.AddRangeAsync(history);

                    // обновляем статус задачи и пользователя
                    oldData.Status = request.Status;
                    oldData.UserId = request.UserId;

                    this.dataContext.Update(oldData);
                    await this.dataContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (CoreException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    // TODO log error
                    transaction.Rollback();
                    throw new CoreException(ResultCode.GenericError);
                }
            }
                
            return request;
        }
    }
}
