﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand: IRequest
    {
        public int Id { get; set; }
    }
}
