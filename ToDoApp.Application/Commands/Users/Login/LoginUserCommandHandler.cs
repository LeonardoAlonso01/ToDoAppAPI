using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.Users;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services.AuthService;

namespace ToDoApp.Application.Commands.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            // Buscar no banco se há um user com esses dados
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            // Se não existir, erro no login
            if (user == null)
            {
                return null;
            }
            // se existir gero o token com os dados do usuário
            var token = _authService.GenerateJwtToken(user.Name, user.Email);
            return new LoginUserViewModel(user.Name, token);
        }
    }
}
