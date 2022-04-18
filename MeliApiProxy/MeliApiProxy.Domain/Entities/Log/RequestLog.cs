namespace MeliApiProxy.Domain.Entities.Log;

public class RequestLog
{
    public int RequestLogId { get; set; }

    public string SourceIp { get; set; }

    public string CompletePath { get; set; }

    public string SimplifiedPath { get; set; }

    public string HttpMethod { get; set; }
    
    public DateTime TimeStamp { get; set; }

    public IList<ResponseLog> ResponseLogs { get; set; }
}