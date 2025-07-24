using System.ComponentModel.DataAnnotations;

namespace TaskManager.Web.Models.Tasks
{
    public class TaskModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A title must be placed")]
        public string Title { get; set; }
        [Required(ErrorMessage = "A description must be placed")]
        public string Description { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "The number must be between 0 and 1")]
        public int Status { get; set; }
    }
}
