namespace TaskManagementAPI.Models
{
    public class TaskCommentModel
    {
        public int TaskCommentid { get; set; }
        public string Comments { get; set; } = string.Empty;
        public int User_Id { get; set; }

        public int task_id { get; set; }
    }
}
