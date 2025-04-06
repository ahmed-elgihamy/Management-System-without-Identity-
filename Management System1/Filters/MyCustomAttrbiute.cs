using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Management_System1.Filters
{
    public class MyCustomAttrbiute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //      | context.ActionDescriptor 
        }
    }
}
