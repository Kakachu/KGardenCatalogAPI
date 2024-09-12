using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KGardenCatalogAPI.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An unexpected error has occurred: Status Code 500");

            context.Result = new ObjectResult("An unexpected error has occurred during request treatment: Status Code 500")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
