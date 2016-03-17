using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.IO;
using System;

namespace LMS.Web.Filters
{
    public class ModelValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool modelState = actionContext.ModelState.IsValid;

            if (!modelState)
            {
                var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0).Select(e =>
                {
                    var exception = e.Value.Errors.First().Exception;
                    return exception != null ? exception.Message : e.Value.Errors.First().ErrorMessage;
                }).ToArray();

                throw new InvalidDataException(string.Join(Environment.NewLine, errors));
            }
        }
    }
}