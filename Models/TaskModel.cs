namespace TaskManagementAPI.Models
{
    public class TaskModel
    {


            public int TaskId { get; set; }
            public string Taskname { get; set; } = string.Empty;
            public int Assigned_Userid { get; set; }

            public string TaskComment { get; set; }


        public string Username { get; set; }
           

          


        
    }
}
