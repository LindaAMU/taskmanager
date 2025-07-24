namespace TaskManager.Web.Models
{
    public class StandardResponce
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string? Message { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
