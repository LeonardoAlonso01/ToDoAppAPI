using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Queries.TaskQueries.GetAllTasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;
using Xunit;

namespace ToDoApp.UnitTests.Application.Queries
{
    public class GetAllTasksQueryHandlerTests
    {
        [Fact]
        public async Task ThreeTasksExist_Executed_ReturnThreeTaskViaewModel()
        {
            // Arange
            var tasks = new List<Tasks>
            {
                new Tasks("A", "AA", 1),
                new Tasks("B", "BB", 1),
                new Tasks("C", "CC", 1)
            };

            var taskRepositoryMock = new Mock<ITaskRepository>();
            taskRepositoryMock.Setup(tr => tr.GetTasksAsync().Result).Returns(tasks);
            var query = new GetAllTasksQuery("", 1);
            var queryHandler = new GetAllTasksQueryHandler(taskRepositoryMock.Object);

            // Act
            var tasksViewModel = await queryHandler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(tasksViewModel);
            Assert.NotEmpty(tasksViewModel);
            Assert.Equal(tasks.Count, tasksViewModel.Count);

            taskRepositoryMock.Verify(tr => tr.GetTasksAsync().Result, Times.Once);
        }
    }
}
