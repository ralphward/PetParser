using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace PetParser.Services
{
    // Basic demonstration of exception handling using ILogger to capture details - this should be extracted out of Services for larger work
    // Should be targeting specific exceptions rather than just ExceptionHandler
    public class ExceptionHandler : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.GetType() + "" + context.Exception.InnerException);
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = 500;
        }
    }
}
