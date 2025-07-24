using TaskManager.Domain.Entities.TaskManager;

namespace TaskManager.API.Models.Tasks
{
    public class TaskListResponse : StandardResponse
    {
        public List<TaskItems> Tasks { get; set; }
    }
}
