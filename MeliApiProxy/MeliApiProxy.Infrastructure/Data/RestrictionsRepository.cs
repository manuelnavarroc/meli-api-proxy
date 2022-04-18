using MeliApiProxy.Domain.Entities.Restriction;
using MeliApiProxy.Domain.Interfaces;

namespace MeliApiProxy.Infrastructure.Data;

public class RestrictionsRepository : IRestrictionsRepository
{
    private readonly LogAndRestrictionsDbContext _dbcontext;

    public RestrictionsRepository(LogAndRestrictionsDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public IList<RestrictionByIp> GetAllRestrictionsByIp()
    {
        return _dbcontext.RestrictionByIp.ToList();
    }

    public IList<RestrictionByPath> GetAllRestrictionsByPath()
    {
        return _dbcontext.RestrictionByPath.ToList();
    }

    public IList<RestrictionByIpAndPath> GetAllRestrictionByIpAndPath()
    {
        return _dbcontext.RestrictionByIpAndPath.ToList();
    }
}