using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace LMS.Web.Filters
{

    public class LMSDbContextFilterAttribute : ActionFilterAttribute
    {
        private readonly Type _dbContextType;

        public LMSDbContextFilterAttribute(Type dbContextType)
        {
            _dbContextType = dbContextType;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var dbContext = Activator.CreateInstance(_dbContextType);

            CallContext.LogicalSetData(LMS.Domain.Consts.DBCONTEXT_KEY, dbContext);
            base.OnActionExecuting(actionContext);
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            var currentContext = GetCurrentContext();
            CallContext.LogicalSetData(LMS.Domain.Consts.DBCONTEXT_KEY, null);

            if (currentContext != null)
            {
                currentContext.Dispose();
            }

        }

        private DbContext GetCurrentContext()
        {
            return (DbContext)CallContext.LogicalGetData(LMS.Domain.Consts.DBCONTEXT_KEY);

        }
    }
}