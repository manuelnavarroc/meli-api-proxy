using MeliApiProxy.Domain.Entities;
using MeliApiProxy.Domain.Entities.Restriction;
using MeliApiProxy.Domain.Interfaces;

namespace MeliApiProxy.Domain.Services;

public class RestrictionsService : IRestrictionsService
{
    private readonly IRestrictionsRepository _restrictionsRepository;
    private IList<RestrictionByIp> _restrictionsByIp;
    private IList<RestrictionByPath> _restrictionsByPath;
    private IList<RestrictionByIpAndPath> _restrictionsByIpAndPath;

    public RestrictionsService(IRestrictionsRepository restrictionsRepository)
    {
        _restrictionsRepository = restrictionsRepository;
        //TODO: implement memory cache for restrictions
        _restrictionsByIp = _restrictionsRepository.GetAllRestrictionsByIp();
        _restrictionsByPath = _restrictionsRepository.GetAllRestrictionsByPath();
        _restrictionsByIpAndPath = _restrictionsRepository.GetAllRestrictionByIpAndPath();
    }

    public bool IsRequestValid(RequestInfo requestInfo)
    {
        return ValidateRestrictionsByIp(requestInfo.SourceIp) &&
            ValidateRestrictionsByPath(requestInfo.Path) &&
            ValidateRestrictionByIpAndPath(requestInfo.SourceIp, requestInfo.Path);
    }

    private bool ValidateRestrictionsByIp(string sourceIp)
    {
        return true;
    }

    private bool ValidateRestrictionsByPath(string path)
    {
        return true;
    }

    private bool ValidateRestrictionByIpAndPath(string sourceIp, string path)
    {
        return true;
    }
}