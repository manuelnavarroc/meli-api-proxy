using MeliApiProxy.Domain.Entities.Log;
using MeliApiProxy.Domain.Interfaces;

namespace MeliApiProxy.Infrastructure.Data;

public class LogsRepository : ILogsRepository
{
    private LogAndRestrictionsDbContext _dbcontext;

    public LogsRepository(LogAndRestrictionsDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public int InsertRequestLog(RequestLog requestLog)
    {
        _dbcontext.Add(requestLog);
        return _dbcontext.SaveChanges();
    }

    public int InsertResponseLog(ResponseLog responseLog)
    {
        _dbcontext.Add(responseLog);
        return _dbcontext.SaveChanges();
    }
}