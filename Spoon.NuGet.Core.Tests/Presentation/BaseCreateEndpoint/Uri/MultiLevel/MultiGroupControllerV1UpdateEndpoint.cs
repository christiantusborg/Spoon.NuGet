using MediatR;
using Microsoft.AspNetCore.Http;
using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel;

public class MultiGroupControllerV1UpdateEndpoint : BaseEndpoint 
{
    private IResult EndpointHandler(Guid groupControllerId, ISender sender, CancellationToken cancellationToken)
    {
        return Results.Ok();
    }
}