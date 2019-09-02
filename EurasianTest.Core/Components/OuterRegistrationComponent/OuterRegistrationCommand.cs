using AutoMapper;
using EurasianTest.Core.Components.OuterRegistrationComponent.Models;
using EurasianTest.Core.Factories;
using EurasianTest.Core.Infrastructure;
using EurasianTest.DAL;
using EurasianTest.DAL.Entities.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EurasianTest.Core.Components.OuterRegistrationComponent
{
    public class OuterRegistrationCommand : ICommand<OuterRegistrationViewModel, OuterRegistrationViewModel>
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public OuterRegistrationCommand(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext ?? throw new NotImplementedException(nameof(DataContext));
            this.mapper = mapper ?? throw new NotImplementedException(nameof(IMapper));
        }

        public async Task<OuterRegistrationViewModel> ExecuteAsync(OuterRegistrationViewModel request)
        {
            if (await this.dataContext.Users.AnyAsync(x => x.Email == request.Email))
            {
                throw new CoreException(ResultCode.UserAlreadyExist);
            }

            var newUser = UserFactory.Create(request.Email, request.Password);

            await this.dataContext.Users.AddAsync(newUser);
            await this.dataContext.SaveChangesAsync();

            return request;
        }
    }
}
