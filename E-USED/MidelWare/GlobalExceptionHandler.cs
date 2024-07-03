using E_USED.Models.Entity.Product;
using Microsoft.AspNetCore.Diagnostics;

namespace E_USED.MidelWare
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Error Here");
            httpContext.Response.Redirect("/Home/Error");
            return true;
        }
    }
}
