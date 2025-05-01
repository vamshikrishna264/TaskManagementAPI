using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId {  get; set; }
        [Required(ErrorMessage = "Please enter the TaskName")]
        [StringLength(100)]
        public string Taskname { get; set; }
        [ForeignKey("Assignedusers")]
        public int Assigned_Userid { get;set; }


        
        public ICollection<TaskComments>? taskcomments { get; set; }

        public virtual Users? Assignedusers { get; set; }

        
    }
}
