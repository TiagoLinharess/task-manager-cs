using task_manager.Application.UseCases.Commons;
using task_manager.Communications.Requests;
using task_manager.Communications.Responses;
using task_manager.Communications.Result;

namespace task_manager.Application.UseCases.Create
{
    public class CreateTaskUseCase
    {
        public Result<ResponseTaskJson> Execute(RequestTaskJson request)
        {
            var errors = RegisterValidation.Execute(request);

            if (errors.Any())
            {
                var errorResponse = new ResponseErrorsJson
                {
                    Errors = errors
                };
                return Result<ResponseTaskJson>.Fail(errorResponse);
            }

            var createdTask = new ResponseTaskJson
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Priority = request.Priority,
                DueDate = request.DueDate,
                Status = request.Status
            };

            return Result<ResponseTaskJson>.Ok(createdTask);
        }
    }
}
