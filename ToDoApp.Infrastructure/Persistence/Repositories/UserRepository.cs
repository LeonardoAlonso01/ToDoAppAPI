using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoAppContext _appContext;

        public UserRepository(ToDoAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _appContext.Users.AddAsync(user);
            await _appContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _appContext.Users.Remove(user);
            await _appContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _appContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _appContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _appContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateUserAsync()
        {
            await _appContext.SaveChangesAsync();
        }
    }
}
