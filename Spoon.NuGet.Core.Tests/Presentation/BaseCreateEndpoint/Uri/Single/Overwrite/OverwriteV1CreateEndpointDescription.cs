using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1CreateEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - Creating a new Base";
    }
}