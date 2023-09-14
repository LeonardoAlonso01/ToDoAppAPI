using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.TasksCommands.CreateTask;

namespace ToDoApp.Application.Validators.TasksValidation
{
    public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Título da tarefa é obrigatório!");

            RuleFor(t => t.Title)
                .MaximumLength(50)
                .WithMessage("Título deve conter no máximo 50 caracteres!");
        }
    }
}
