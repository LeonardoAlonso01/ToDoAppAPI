using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Entities;

namespace ToDoApp.Infrastructure.Persistence.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.
                ToTable("TTasks")
                .HasKey(t => t.Id);

            builder.HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
