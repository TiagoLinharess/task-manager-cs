using Microsoft.AspNetCore.Mvc;
using task_manager.Application.UseCases;
using task_manager.Application.UseCases.Create;
using task_manager.Application.UseCases.Read;
using task_manager.Application.UseCases.Update;
using task_manager.Communications.Requests;
using task_manager.Communications.Responses;

namespace task_manager.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status204NoContent)]
        public IActionResult Read()
        {
            var useCase = new ReadAllTasksUseCase();
            var response = useCase.Execute();
            if (response.Tasks.Any())
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Read([FromRoute] Guid id)
        {
            var useCase = new ReadAtTaskUseCase();
            var response = useCase.Execute(id);
            if (response is not null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] RequestTaskJson request)
        {
            var useCase = new CreateTaskUseCase();
            var response = useCase.Execute(request);

            if (response.Success && response.Data is not null)
            {
                return Created(string.Empty, response.Data);
            }
            else if (!response.Success && response.ErrorMessage is not null)
            {
                return BadRequest(response.ErrorMessage);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestTaskJson request)
        {
            var useCase = new UpdateTaskUseCase();
            var response = useCase.Execute(id, request);

            if (response.Success && response.Data is not null)
            {
                return NoContent();
            }
            else if (!response.Success && response.ErrorMessage is not null)
            {
                return BadRequest(response.ErrorMessage);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteTaskUseCase();
            var response = useCase.Execute(id);

            if (response)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
