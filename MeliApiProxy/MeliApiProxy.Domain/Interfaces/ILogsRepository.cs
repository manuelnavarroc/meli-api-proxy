using MeliApiProxy.Domain.Entities.Log;

namespace MeliApiProxy.Domain.Interfaces;

public interface ILogsRepository
{
    int InsertRequestLog(RequestLog requestLog);

    int InsertResponseLog(ResponseLog responseLog);
}