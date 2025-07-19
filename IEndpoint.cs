using Microsoft.AspNetCore.Routing;

namespace TS.Endpoints;
public interface IEndpoint
{
    void AddRoutes(IEndpointRouteBuilder builder);
}
