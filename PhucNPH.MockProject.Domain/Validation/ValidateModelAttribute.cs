using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhucNPH.MockProject.Domain.Constants;
using PhucNPH.MockProject.Domain.Ulitilities;

namespace PhucNPH.MockProject.Domain.Validation
{
    public class ValidateModelAttribute : IActionFilter, IFilterMetadata
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

                context.Result = new BadRequestObjectResult(new ResponseResult(400, errors));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
