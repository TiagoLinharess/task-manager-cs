using task_manager.Communications.Responses;

namespace task_manager.Application.UseCases.Read
{
    public class ReadAtTaskUseCase
    {
        public ResponseTaskJson? Execute(Guid id)
        {
            return new ResponseTaskJson
            {
                Id = id,
                Name = "Sample Task",
                Description = "This is a sample task description.",
                Priority = Communications.Enums.TaskPriority.Medium,
                DueDate = DateTime.UtcNow.AddDays(7),
                Status = Communications.Enums.TaskStatus.Pending
            };
        }
    }
}
