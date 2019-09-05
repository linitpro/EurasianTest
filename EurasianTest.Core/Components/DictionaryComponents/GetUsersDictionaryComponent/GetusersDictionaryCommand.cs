﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent
{
    public class GetUsersDictionaryCommand: ICommand<GetUsersDictionaryRequestViewModel, List<UserViewModel>>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public GetUsersDictionaryCommand(DataContext dataContext
            , IMapper mapper
            )
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<List<UserViewModel>> ExecuteAsync(GetUsersDictionaryRequestViewModel request)
        {
            return await this.dataContext
                .Users
                .Where(x => x.IsDeleted == false && request.Roles.Any(a => a == x.Role))
                .ProjectTo<UserViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}