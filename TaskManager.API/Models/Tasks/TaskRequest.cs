using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Models.Tasks
{
    public class TaskRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
