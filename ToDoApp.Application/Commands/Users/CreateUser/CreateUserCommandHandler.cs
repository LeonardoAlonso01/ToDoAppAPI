using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services.AuthService;
using ToDoApp.Core.Services.EmailService;

namespace ToDoApp.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService, IEmailService emailService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _emailService = emailService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.GetUserByEmailAsync(request.Email);

            if (userExists == null)
            {
                var password = _authService.ComputeSha256Hash(request.Password);
                var user = new User(request.Name, request.Email, password);

                if (user != null)
                {
                    await _userRepository.CreateUserAsync(user);
                    // await _emailService.SendEmail("Leooalonso@gmail.com", user.Email, "Conta criada com sucesso", "Criação de conta ToDoApp");
                    return user.Id;
                }
                else
                {
                    return 0;
                }

            }
            return 0;
        }
    }
}
