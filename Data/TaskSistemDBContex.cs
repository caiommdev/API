using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using API.Models;

namespace API.Data
{
    public class TaskSistemDBContex : DbContext
    {
        public TaskSistemDBContex(DbContextOptions<TaskSistemDBContex> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity<TaskModel>().ToTable("Tasks");
        }
    }
}