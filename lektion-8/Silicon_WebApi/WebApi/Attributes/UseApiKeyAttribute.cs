using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Attributes;


[AttributeUsage(AttributeTargets.All)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
        var secret = configuration?["ApiKey:Secret"];

        if (!string.IsNullOrEmpty(secret) && context.HttpContext.Request.Query.TryGetValue("key", out var key))
        {
            if (!string.IsNullOrEmpty(key) && secret == key)
            {
                await next();
                return;
            }
        }

        context.Result = new UnauthorizedResult();
    }
}
