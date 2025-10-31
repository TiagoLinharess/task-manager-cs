using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_manager.Communications.Requests;
using task_manager.Communications.Responses;
using task_manager.Communications.Result;

namespace task_manager.Application.UseCases.Commons
{
    internal class RegisterValidation
    {
        public static List<string> Execute(RequestTaskJson request)
        {
            var results = new List<string>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                results.Add("Task name is required.");
            }

            if (request.Name.Length > 100)
            {
                results.Add("Task name cannot exceed 100 characters.");
            }

            if (request.DueDate < DateTime.UtcNow)
            {
                results.Add("Due date cannot be in the past.");
            }

            if (request.Description is not null && request.Description.Length > 500)
            {
                results.Add("Task description cannot exceed 500 characters.");
            }

            if ((int)request.Status > 2)
            {
                results.Add("Invalid task status.");
            }

            if ((int)request.Priority > 2)
            {
                results.Add("Invalid task priority.");
            }

            return results;
        }
    }
}
