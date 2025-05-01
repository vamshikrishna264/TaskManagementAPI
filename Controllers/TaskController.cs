using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    
    public class TaskController : ControllerBase
    {
        private TaskApplicationDbContext _context;

        public TaskController(TaskApplicationDbContext context) //injecting DbContext class into controller
        {
            _context = context;
        }

        [Authorize(Roles ="Admin")] //Given permission to the Admin to access this method
        [HttpPost]
        public async Task<ActionResult<TaskModel>> tasks([FromBody] TaskModel task1) //Here we are using tasks to acheive threading
        {

            var task = new TaskModel  //creating a class instance of Task Model
            {
                Taskname = task1.Taskname,
                Assigned_Userid = task1.Assigned_Userid,
                TaskComment=task1.TaskComment
            };
            Tasks tasks=new Tasks();
            tasks.Taskname = task1.Taskname;
            
            int userid=task1.Assigned_Userid;
            var user = await _context.Users.FindAsync(userid);// find the user who exists with the userid

            Users users=new Users();

            users.Name =task1.Username;
            if (user==null)
            {
                userid = 0;
                _context.Users.Add(users);// Adding the users to database Users
                await _context.SaveChangesAsync(); // it impacts the database to make changes and add the new row in the table
                userid = users.Id;
            }

            tasks.Assigned_Userid= userid;
            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            int taskid = tasks.TaskId;
            TaskComments comment = new TaskComments();

            comment.Comments = task.TaskComment;
            comment.task_id = taskid;
            comment.user_id = userid;

            _context.TaskComments.Add(comment);
             await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetTask),new {Id=task.TaskId },task);



        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Tasks>> GetTask(int Id)// it is used toretrieve the task by id
        {
            var task= await _context.Tasks.Include(t=>t.taskcomments).Include(t=>t.Assignedusers).FirstOrDefaultAsync(t=>t.TaskId == Id);
            
            
            return Ok(task);

        }

        [HttpGet("user/{userid}")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetUserTasks(int userid)// get tasks of particular user
        {
            var task = await _context.Tasks.Where(t => t.Assigned_Userid == userid).Include(t => t.taskcomments).Include(t => t.Assignedusers).ToListAsync();
           
            
            return Ok(task);

        }
    }
}
