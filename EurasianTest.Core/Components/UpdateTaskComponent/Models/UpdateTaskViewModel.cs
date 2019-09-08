using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.UpdateTaskComponent.Models
{
    public class UpdateTaskViewModel
    {
        public UpdateTaskViewModel()
        {
            this.Name = "";
            this.Description = "";
        }

        public Int64 Id { set; get; }

        private String name;

        public String Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return this.name?.Trim() ?? "";
            }
        }

        private String description;

        public String Description
        {
            set
            {
                this.description = value;
            }
            get
            {
                return this.description?.Trim() ?? "";
            }
        }

        public DateTime Started { set; get; }

        public DateTime Expired { set; get; }
    }

    public class UpdateTaskViewModelValidator : AbstractValidator<UpdateTaskViewModel>
    {
        public UpdateTaskViewModelValidator()
        {
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("Минимальная длинна 3 символа");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Минимальная длинна 3 символа");
        }
    }
}
