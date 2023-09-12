using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Enums;

namespace ToDoApp.Application.ViewModels.TasksViewModels
{
    public class TaskViewModel
    {
        public string Title { get; private set; }
        public StatusTask Status { get; private set; }

        public TaskViewModel(string title, StatusTask status)
        {
            Title = title;
            Status = status;
        }
    }
}
