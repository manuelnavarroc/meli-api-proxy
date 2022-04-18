namespace MeliApiProxy.Domain.Entities.Log;

public class ResponseLog
{
    public int ResponseLogId { get; set; }

    public int RequestLogId { get; set; }

    public string ResponseCode { get; set; }

    public DateTime TimeStamp { get; set; }

    public RequestLog RequestLog { get; set; }
}