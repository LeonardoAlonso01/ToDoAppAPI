using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Tasks> Tasks { get; private set; }


        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Tasks = new List<Tasks>();
            CreatedAt = DateTime.Now;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
