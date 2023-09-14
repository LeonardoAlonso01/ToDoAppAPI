using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.Users.CreateUser;
using ToDoApp.Application.Commands.Users.UpdateUser;

namespace ToDoApp.Application.Validators.Users
{
    public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido!s");

            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório");

        }
    }
}
