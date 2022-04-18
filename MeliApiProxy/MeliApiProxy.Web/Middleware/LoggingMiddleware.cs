using MeliApiProxy.Domain.Entities.Log;
using MeliApiProxy.Domain.Interfaces;
using MeliApiProxy.Web.Models.Extensions;

namespace MeliApiProxy.Web.Middleware;

public class LoggingMiddleware
{
    private RequestDelegate next;

    public LoggingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(
        HttpContext context, 
        IRequestLogService requestLogService)
    {
        var requestLog = new RequestLog().GetFromContext(context);

        try
        {
            requestLogService.LogRequest(requestLog);
            await this.next(context);
        }
        finally
        {
            requestLogService.LogResponse(new ResponseLog(){
                RequestLog = requestLog,
                ResponseCode = context.Response.StatusCode.ToString(),
                TimeStamp = DateTime.UtcNow
            });
        }
    }
}
