using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.ViewModels.Users
{
    public class UserDetailViewModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserDetailViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
