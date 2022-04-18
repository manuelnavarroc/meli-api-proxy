
using MeliApiProxy.Domain.Entities;

namespace MeliApiProxy.Domain.Interfaces;

public interface IRestrictionsService
{
    bool IsRequestValid(RequestInfo requestInfo);
}