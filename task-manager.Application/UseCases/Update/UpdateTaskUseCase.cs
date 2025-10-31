using task_manager.Application.UseCases.Commons;
using task_manager.Communications.Requests;
using task_manager.Communications.Responses;
using task_manager.Communications.Result;

namespace task_manager.Application.UseCases.Update
{
    public class UpdateTaskUseCase
    {
        public Result<ResponseTaskJson> Execute(Guid id, RequestTaskJson request)
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

            return Result<ResponseTaskJson>.Ok(new ResponseTaskJson
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Priority = request.Priority,
                DueDate = request.DueDate,
                Status = request.Status
            });
        }
    }
}
