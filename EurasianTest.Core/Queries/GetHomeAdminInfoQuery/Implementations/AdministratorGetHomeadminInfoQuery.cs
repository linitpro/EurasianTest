using EurasianTest.Core.Components.GetHomeInfoModel.Model;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskStatus = EurasianTest.DAL.Entities.Enums.TaskStatus;

namespace EurasianTest.Core.Queries.GetHomeAdminInfoQuery.Implementations
{
    public class AdministratorGetHomeadminInfoQuery: IGetHomeadminInfoQuery
    {
        private readonly DataContext dataContext;

        public AdministratorGetHomeadminInfoQuery(DataContext dataContext
            
            )
        {
            this.dataContext = dataContext;
        }

        public Role Role
        {
            get
            {
                return Role.Administrator;
            }
        }

        public async Task<GetHomeAdminInfoViewModel> ExecuteAsync()
        {
            GetHomeAdminInfoViewModel result = new GetHomeAdminInfoViewModel();

            var count = await this.dataContext
                .GetHomeAdminInfoQuery
                .FromSql(
                $@"SELECT (
                        SELECT COUNT(DISTINCT this.""TaskId"")
                        FROM public.""Tasks"" tsks
                        INNER JOIN public.""TaskHistories"" this ON tsks.""Id"" = this.""TaskId""
                        WHERE this.""NewStatus"" = {(Int32)TaskStatus.Closed} 
                            AND EXTRACT(WEEK FROM this.""Created"") = EXTRACT(WEEK FROM NOW())
                            AND tsks.""Status"" = {(Int32)TaskStatus.Closed} 
	                ) AS ""FinishedDateOnTheWeek"",
	                (
		                SELECT COUNT(DISTINCT this.""TaskId"")
                        FROM public.""Tasks"" tsks
                        INNER JOIN public.""TaskHistories"" this ON tsks.""Id"" = this.""TaskId""
                        WHERE this.""NewStatus"" = {(Int32)TaskStatus.Returned}
                            AND EXTRACT(WEEK FROM this.""Created"") = EXTRACT(WEEK FROM NOW())
	                ) AS ""ReturnedForWorkInTheWeek"""
                ).FirstOrDefaultAsync();

            result.FinishedDateOnTheWeek = count.FinishedDateOnTheWeek;
            result.ReturnedForWorkInTheWeek = count.ReturnedForWorkInTheWeek;

            return result;
        }
    }
}
