using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1UpdateEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - Update a new Base";
    }
}