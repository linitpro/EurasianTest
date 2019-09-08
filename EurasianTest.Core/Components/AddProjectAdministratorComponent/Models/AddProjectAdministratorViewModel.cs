using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddProjectAdministratorComponent.Models
{
    public class AddProjectAdministratorViewModel
    {
        public Int64 Id { set; get; }

        public Int64? UserId { set; get; }
    }

    public class AddProjectAdministratorViewModelvalidator: AbstractValidator<AddProjectAdministratorViewModel>
    {
        public AddProjectAdministratorViewModelvalidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("Не может быть пустым");
        }
    }
}
