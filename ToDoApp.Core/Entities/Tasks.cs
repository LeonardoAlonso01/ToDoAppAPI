using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;

namespace ToDoApp.Core.Entities
{
    public class Tasks: BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public int IdUser { get; private set; }
        public User User { get; private set; }  

        public StatusTask Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        

        public Tasks(string title, string description, int idUser)
        {
            Title = title;
            Description = description;
            IdUser = idUser;
            Status = StatusTask.Open;
            CreatedAt = DateTime.Now;
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        } 

        public void Cancel()
        {
            if (Status == StatusTask.Open)
            {
                Status = StatusTask.Cancelled;
            }
        }

        public void Finish()
        {
            if (Status == StatusTask.Open)
            {
                Status = StatusTask.Done;
            }
        }

        public void Reopen()
        {
            if (Status == StatusTask.Done || Status == StatusTask.Cancelled)
            {
                Status = StatusTask.Open;
            }
        }
    }
}
