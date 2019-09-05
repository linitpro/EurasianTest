using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent
{
    public class GetProjectsDictionaryCommand: ICommand<GetProjectsDictionaryRequestViewModel, List<ProjectViewModel>>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public GetProjectsDictionaryCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<List<ProjectViewModel>> ExecuteAsync(GetProjectsDictionaryRequestViewModel request)
        {
            return await this.dataContext
                .Projects
                .Where(x => true) // TODO добавить разделение для админа проекта
                .ProjectTo<ProjectViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
