using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Models;
namespace TaskManager.Data
{
    public class ManagerContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TaskList> TaskList { get; set; }
        public virtual DbSet<SignedUsers> SignedUsers { get; set; }

        public ManagerContext()
        {

        }
        public ManagerContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>(entity =>
            {
                


                entity
                .HasOne(t => t.TaskList)
                .WithMany(tl => tl.Tasks)
                .HasForeignKey(t => t.TaskListId)
                .OnDelete(DeleteBehavior.NoAction);  
            });
            modelBuilder.Entity<TaskList>(entity =>
            {
                entity
                .HasOne(t => t.User)
                .WithMany(u => u.TaskList)
                .HasForeignKey(t => t.UserId);
            });
            
        }

    }
}
