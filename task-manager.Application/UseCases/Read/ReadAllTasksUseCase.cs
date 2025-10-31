using task_manager.Communications.Responses;

namespace task_manager.Application.UseCases.Read
{
    public class ReadAllTasksUseCase
    {
        public ResponseAllTasksJson Execute()
        {
            var response = new ResponseAllTasksJson
            {
                Tasks = new List<ResponseTaskJson>
                {
                    new ResponseTaskJson
                    {
                        Id = Guid.NewGuid(),
                        Name = "Task 1",
                        Description = "Description for Task 1",
                        Priority = Communications.Enums.TaskPriority.High,
                        DueDate = DateTime.UtcNow.AddDays(3),
                        Status = Communications.Enums.TaskStatus.Pending
                    },

                    new ResponseTaskJson
                    {
                        Id = Guid.NewGuid(),
                        Name = "Task 2",
                        Description = "Description for Task 1",
                        Priority = Communications.Enums.TaskPriority.High,
                        DueDate = DateTime.UtcNow.AddDays(3),
                        Status = Communications.Enums.TaskStatus.Pending
                    }
                }
            };

            return response;
        }
    }
}
