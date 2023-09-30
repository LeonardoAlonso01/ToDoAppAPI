using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Enums;
using Xunit;

namespace ToDoApp.UnitTests.Core.Entities
{
    public class TasksTests
    {
        [Fact]
        public void TestIfTaskCreateWorks()
        {
            var task = new Tasks("Fazer almoço", "", 1);

            Assert.Equal(StatusTask.Open, task.Status);
            Assert.NotNull(task.Title);
        }

        [Fact]
        public void TestIfTaskCancelledWorks()
        {
            var task = new Tasks("Fazer almoço", "", 1);
            Assert.Equal(StatusTask.Open, task.Status);
            Assert.NotNull(task.Title);

            task.Cancel();

            Assert.Equal(StatusTask.Cancelled, task.Status);
        }

        [Fact]
        public void TestIfTaskReopenWorksIfTaskCancelled()
        {
            var task = new Tasks("Fazer almoço", "", 1);
            Assert.Equal(StatusTask.Open, task.Status);
            Assert.NotNull(task.Title);

            task.Cancel();
            Assert.Equal(StatusTask.Cancelled, task.Status);

            task.Reopen();
            Assert.Equal(StatusTask.Open, task.Status);
        }

        [Fact]
        public void TestIfTaskFinishWorks()
        {
            var task = new Tasks("Fazer almoço", "", 1);
            Assert.Equal(StatusTask.Open, task.Status);
            Assert.NotNull(task.Title);

            task.Finish();
            Assert.Equal(StatusTask.Done, task.Status);
        }

        [Fact]
        public void TestIfTaskReopenWorksIfTaskDones()
        {
            var task = new Tasks("Fazer almoço", "", 1);
            Assert.Equal(StatusTask.Open, task.Status);
            Assert.NotNull(task.Title);

            task.Finish();
            Assert.Equal(StatusTask.Done, task.Status);

            task.Reopen();
            Assert.Equal(StatusTask.Open, task.Status);
        }

        [Fact]
        public void TestIfTaskUpdateWorks()
        {
            var task = new Tasks("Fazer almoço", "", 1);
            Assert.Equal(StatusTask.Open, task.Status);
            Assert.NotNull(task.Title);

            task.Update("Fazer almoço", "Realizar até as 12hrs");
            Assert.NotNull(task.Title);
        }
    }
}
