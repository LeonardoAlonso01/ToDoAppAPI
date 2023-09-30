using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.ViewModels.Users
{
    public class LoginUserViewModel
    {
        public string Name { get; private set; }
        public string Token { get; private set; }

        public LoginUserViewModel(string name, string token)
        {
            Name = name;
            Token = token;
        }
    }
}
