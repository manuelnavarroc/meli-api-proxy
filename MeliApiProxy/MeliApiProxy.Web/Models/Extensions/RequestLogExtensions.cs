using MeliApiProxy.Domain.Entities.Log;
using Microsoft.AspNetCore.Http.Extensions;

namespace MeliApiProxy.Web.Models.Extensions;

public static class RequestLogExtensions
{
    public static RequestLog GetFromContext(this RequestLog requestLog, HttpContext context)
    {
        requestLog.SourceIp = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        requestLog.CompletePath = context.Request.GetDisplayUrl();
        requestLog.SimplifiedPath = context.Request.Path;
        requestLog.HttpMethod = context.Request.Method;
        requestLog.TimeStamp = DateTime.UtcNow;
        return requestLog;
    }
}