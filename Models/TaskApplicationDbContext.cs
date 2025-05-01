using Microsoft.EntityFrameworkCore;

namespace TaskManagementAPI.Models
{
    public class TaskApplicationDbContext:DbContext
    {

        public TaskApplicationDbContext(DbContextOptions<TaskApplicationDbContext> options) : base(options) { }

        public DbSet<Tasks> Tasks { get; set; } 
        public DbSet<Users> Users { get; set; }
        public DbSet<TaskComments> TaskComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskComments>()
                .HasOne(tc => tc.Tasks)
                .WithMany(t => t.taskcomments)
                .HasForeignKey(tc => tc.task_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskComments>()
                .HasOne(tc => tc.Users)
                .WithMany(u => u.taskcomments)
                .HasForeignKey(tc => tc.user_id)
                .OnDelete(DeleteBehavior.Restrict); // To remove the cascade conflict


            ///Seed data to insert into Database
            modelBuilder.Entity<Users>().HasData(

                  new Users { Id = 1, Name = "Alice" },
                  new Users { Id = 2, Name = "Bob" },
                  new Users { Id = 3, Name = "Charlie" },
                  new Users { Id = 4, Name = "Diana" },
                  new Users { Id = 5, Name = "Ethan" }


                );

            modelBuilder.Entity<Tasks>().HasData(
                  new Tasks { TaskId = 1, Taskname = "Build API", Assigned_Userid = 1 },
        new Tasks { TaskId = 2, Taskname = "Write Tests", Assigned_Userid = 2 },
        new Tasks { TaskId = 3, Taskname = "Fix Bugs", Assigned_Userid = 3 },
        new Tasks { TaskId = 4, Taskname = "Deploy to Server", Assigned_Userid = 4 },
        new Tasks { TaskId = 5, Taskname = "Code Review", Assigned_Userid = 5 }

                );

            modelBuilder.Entity<TaskComments>().HasData(


          new TaskComments { TaskCommentid = 1, Comments = "Initial setup done", task_id = 1, user_id = 1 },
        new TaskComments { TaskCommentid = 2, Comments = "Test cases added", task_id = 2, user_id = 2 },
        new TaskComments { TaskCommentid = 3, Comments = "Fixed issue #123", task_id = 3, user_id = 2 },
        new TaskComments { TaskCommentid = 4, Comments = "Deployed successfully", task_id = 4, user_id = 4 },
        new TaskComments { TaskCommentid = 5, Comments = "Reviewed and approved", task_id = 5, user_id = 5 }
                );

            
        }

    }
}
