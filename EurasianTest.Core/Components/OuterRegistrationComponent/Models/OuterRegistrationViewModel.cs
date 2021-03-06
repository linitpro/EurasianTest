﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.OuterRegistrationComponent.Models
{
    /// <summary>
    /// Модель представления для внешней регистрации пользователя
    /// </summary>
    public class OuterRegistrationViewModel
    {
        public OuterRegistrationViewModel()
        {
            this.email = "";
            this.password = "";
        }

        private String email;
        private String password;

        /// <summary>
        /// Эл.почта
        /// </summary>
        public String Email
        {
            set
            {
                this.email = value;
            }
            get
            {
                return this.email?.Trim().ToLower() ?? "";
            }
        }

        /// <summary>
        /// Пароль
        /// </summary>
        public String Password
        {
            set
            {
                this.password = value;
            }
            get
            {
                return this.password?.Trim() ?? "";
            }
        }
    }

    public class OuterRegistrationViewModelValidator : AbstractValidator<OuterRegistrationViewModel>
    {
        public OuterRegistrationViewModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Должно содержать действительный адрес эл. почты");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Не может быть пустым");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Минимальная длина 6 символов");
        }
    }
}
