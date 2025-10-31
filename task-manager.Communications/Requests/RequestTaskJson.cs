using task_manager.Communications.Enums;
using TaskStatus = task_manager.Communications.Enums.TaskStatus;

namespace task_manager.Communications.Requests
{
    public class RequestTaskJson
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
    }
}
