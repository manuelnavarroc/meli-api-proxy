using MeliApiProxy.Domain.Entities.Log;

namespace MeliApiProxy.Domain.Interfaces;

public interface IRequestLogService
{
    int LogRequest(RequestLog requestLog);

    int LogResponse(ResponseLog responseLog);
}