using MeliApiProxy.Domain.Entities.Restriction;

namespace MeliApiProxy.Domain.Interfaces;

public interface IRestrictionsRepository
{
    IList<RestrictionByIp> GetAllRestrictionsByIp();

    IList<RestrictionByPath> GetAllRestrictionsByPath();

    IList<RestrictionByIpAndPath> GetAllRestrictionByIpAndPath();
}