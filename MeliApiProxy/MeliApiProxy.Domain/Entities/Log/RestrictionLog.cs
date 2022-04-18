namespace MeliApiProxy.Domain.Entities.Log;

public class RestrictionLog
{
    public int RestrictionLogId { get; set; }

    public int RestrictionId { get; set; }

    public string SourceIpPattern { get; set; }

    public string PathPattern { get; set; }

    public int MaxHits { get; set; }

    public int MinutesTimeStamp { get; set; }

    public bool DenyRequest { get; set; }

    public DateTime TimeStamp { get; set; }
}