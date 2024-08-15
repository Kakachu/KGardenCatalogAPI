using Microsoft.AspNetCore.Mvc.Filters;

namespace KGardenCatalogAPI.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //executes before Action
            _logger.LogInformation("--- Executing -> OnActionExecuting ---");
            _logger.LogInformation("------------------------------------------------");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
            _logger.LogInformation("------------------------------------------------");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //executes before after
            _logger.LogInformation("--- Executing -> OnActionExecuted ---");
            _logger.LogInformation("------------------------------------------------");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"Status Code : {context.HttpContext.Response.StatusCode}");
            _logger.LogInformation("------------------------------------------------");
        }


    }
}
