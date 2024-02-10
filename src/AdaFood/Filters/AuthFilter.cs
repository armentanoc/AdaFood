
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdaFood.WebAPI.Filters
{
    public class AuthFilter : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var isAdmin = context.HttpContext.Request.Query["admin"].ToString();

            if (isAdmin.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
