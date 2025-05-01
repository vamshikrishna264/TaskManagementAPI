using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter the Name")]
        [StringLength(10)]
        public string Name { get; set; }

        public ICollection<Tasks> tasks { get; set; }
        public ICollection<TaskComments> taskcomments { get; set; }


    }
}
