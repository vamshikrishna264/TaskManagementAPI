using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementAPI.Models
{
    public class TaskComments
    {
        [Key]
        public int TaskCommentid { get; set; }
       
        
        public string Comments {  get; set; }
        [ForeignKey("Tasks")]
        public int task_id { get; set; }
        [ForeignKey("Users")]
        public int user_id {  get; set; }
        public Tasks Tasks { get; set; }
       
        public Users Users { get; set; }
    }
}
