using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;

namespace ToDoApp.Application.ViewModels.TasksViewModels
{
    public class TasksDetailViewModel
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public StatusTask Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public TasksDetailViewModel(string title, string description, StatusTask status, DateTime createdAt)
        {
            Title = title;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
