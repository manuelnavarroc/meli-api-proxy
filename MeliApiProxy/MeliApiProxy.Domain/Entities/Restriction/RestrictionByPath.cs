namespace MeliApiProxy.Domain.Entities.Restriction;

public class RestrictionByPath
{
    public int RestrictionByPathId { get; set; }

    public string PathPattern { get; set; }

    public int MaxHits { get; set; }

    public int MinutesTimeSpan { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }
}