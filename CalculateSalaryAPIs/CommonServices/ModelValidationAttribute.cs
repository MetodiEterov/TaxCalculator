using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.CommonServices
{
	public class ModelValidationAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState); 
			}
		}
	}
}
