using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Walk_and_Trails_of_SA_API.CustomActionFilters
{
    public class ValidateModelAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid==false)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
