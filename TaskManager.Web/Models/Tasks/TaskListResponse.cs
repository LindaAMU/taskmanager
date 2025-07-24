namespace TaskManager.Web.Models.Tasks
{
    public class TaskListResponse : StandardResponce
    {
        public List<TaskModel> Tasks { get; set; }
    }
}
