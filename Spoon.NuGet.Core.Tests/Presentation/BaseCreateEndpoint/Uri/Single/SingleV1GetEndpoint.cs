using MediatR;
using Microsoft.AspNetCore.Http;
using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single;

public class SingleV1GetEndpoint : BaseEndpoint 
{

    private IResult EndpointHandler(Guid singleId, ISender sender, CancellationToken cancellationToken)
    {
        return Results.Ok();
    }
}