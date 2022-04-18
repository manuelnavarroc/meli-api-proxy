using MeliApiProxy.Domain.Entities;
using MeliApiProxy.Domain.Interfaces;

namespace MeliApiProxy.Web.Middleware;

public class RestrictionsMiddleware
{
    private RequestDelegate next;

    public RestrictionsMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(
        HttpContext context,
        IRestrictionsService restrictionsService)
    {
        var requestInfo = new RequestInfo()
        {
            Path = context.Request.Path,
            SourceIp = context.Connection.RemoteIpAddress.MapToIPv4().ToString()
        };

        if (!restrictionsService.IsRequestValid(requestInfo))
        {
            context.Response.Clear();
            context.Response.StatusCode = 429;
            await context.Response.WriteAsync("Too Many Requests");
            return;
        }

        await this.next(context);
    }
}
