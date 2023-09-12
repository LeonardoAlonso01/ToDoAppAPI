using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.Users;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Application.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetailViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);

            if (user != null)
            {
                var userDetailView = new UserDetailViewModel(user.Name, user.Email);
                return userDetailView;
            }

            return null;

        }
    }
}
