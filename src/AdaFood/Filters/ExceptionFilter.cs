using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdaFood.WebAPI.Filters
{
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {

            var statusCode = StatusCodes.Status500InternalServerError;

            var objectResponse = new
            {
                Error = new
                {
                    message = context.Exception.Message,
                    statusCode = statusCode
                }
            };

            context.Result = new ObjectResult(objectResponse)
            {
                StatusCode = statusCode
            };

            await Task.CompletedTask;
        }
    }
}
