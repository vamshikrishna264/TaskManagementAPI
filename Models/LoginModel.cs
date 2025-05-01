using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter the UserName")]
        [StringLength(10)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
       
        public string Password { get; set; }
    }

    public enum UserRoles
    {
        Admin,

        User
    }
}
