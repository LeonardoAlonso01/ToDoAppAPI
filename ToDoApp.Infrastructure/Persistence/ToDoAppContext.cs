using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;

namespace ToDoApp.Infrastructure.Persistence
{
    public class ToDoAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

