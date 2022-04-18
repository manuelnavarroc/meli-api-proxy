using MeliApiProxy.Domain.Entities.Log;
using MeliApiProxy.Domain.Interfaces;

namespace MeliApiProxy.Domain.Services;

public class RequestLogService : IRequestLogService
{
    private readonly ILogsRepository _logsRepository;

    public RequestLogService(ILogsRepository logsRepository)
    {
        _logsRepository = logsRepository;
    }

    public int LogRequest(RequestLog requestLog)
    {
        return _logsRepository.InsertRequestLog(requestLog);
    }

    public int LogResponse(ResponseLog responseLog)
    {
        return _logsRepository.InsertResponseLog(responseLog);
    }
}