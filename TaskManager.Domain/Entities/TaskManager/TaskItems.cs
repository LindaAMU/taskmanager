namespace TaskManager.Domain.Entities.TaskManager
{
    public class TaskItems
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Status { get; set; }
    }
}
