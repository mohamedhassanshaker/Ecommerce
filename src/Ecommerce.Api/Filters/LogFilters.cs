using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Api.Filters
{
    public class LogFilters : IActionFilter
    {
        private readonly ILogger<LogFilters> logger;

        public LogFilters(ILogger<LogFilters> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation(context.HttpContext.Response.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation(context.HttpContext.Request.ToString());
        }
    }
}
