using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using Xunit;

namespace ToDoApp.UnitTests.Core.Entities
{
    public class UserTests
    {
        [Fact]
        public void TestIfUserCreateWorks()
        {
            var user = new User("Paulo", "Paulo@gmail.com", "1234Ad!");

            Assert.NotNull(user);
            Assert.NotEmpty(user.Name);
            Assert.NotEmpty(user.Email);
            Assert.NotEmpty(user.Password);
        }

        public void TestIfUserUpdateWorks()
        {
            var user = new User("Paulo", "Paulo@gmail.com", "1234Ad!");

            Assert.NotNull(user);
            Assert.NotEmpty(user.Name);
            Assert.NotEmpty(user.Email);
            Assert.NotEmpty(user.Password);

            user.Update("Paulo", "Paulo@Comercial.com");

            Assert.NotEmpty(user.Name);
            Assert.NotEmpty(user.Email);
        }
    }
}
