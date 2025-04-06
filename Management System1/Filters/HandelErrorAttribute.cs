using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Management_System1.Filters
{
    public class HandelErrorAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error"; // write any thing you want that apper

            ContentResult contentResult = new ContentResult();
            contentResult.Content = "there is Exception throw";




            context.Result = contentResult;
        }

        // for use it [HandelError]  or if want use global want write in program.cs addControllersWithViews s=>s.filters.add(new handelerrorattribute())
    }
}
