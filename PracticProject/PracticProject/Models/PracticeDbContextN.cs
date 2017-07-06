using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PracticProject.Models.TasksFolder;
using PracticProject.Models.UsersFolder;

namespace PracticProject.Models
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext() : base("name=PracticeDbContext") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Language> Languages { get; set; }

    }
}