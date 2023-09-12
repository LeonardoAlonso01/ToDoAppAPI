using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModels.Users;

namespace ToDoApp.Application.Queries.Users.GetUser
{
    public class GetUserQuery : IRequest<UserDetailViewModel>
    {
        public int Id { get; set; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
