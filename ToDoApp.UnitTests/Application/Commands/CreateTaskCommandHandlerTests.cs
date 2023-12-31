﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.TasksCommands.CreateTask;
using ToDoApp.Application.Queries.TaskQueries.GetAllTasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;
using ToDoApp.Infrastructure.Persistence;
using Xunit;

namespace ToDoApp.UnitTests.Application.Commands
{
    public class CreateTaskCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnTaskId()
        {
            //Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var taskRepositoryMock = new Mock<ITaskRepository>();

            unitOfWork.SetupGet(uow => uow.TaskRepository).Returns(taskRepositoryMock.Object);

            var createTaskCommand = new CreateTaskCommand
            {
                Title = "Test",
                Description = "Test Description",
                IdUser = 1
            };

            var createTaskCommandHandler = new CreateTaskCommandHandler(unitOfWork.Object);

            //Act
            var id = await createTaskCommandHandler.Handle(createTaskCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            taskRepositoryMock.Verify(tr => tr.CreateTaskAsync(It.IsAny<Tasks>()), Times.Once);
        }

    }
}
