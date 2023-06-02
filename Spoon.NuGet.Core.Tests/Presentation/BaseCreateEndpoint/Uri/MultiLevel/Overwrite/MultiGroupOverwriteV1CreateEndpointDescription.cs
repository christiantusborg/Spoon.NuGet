using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1CreateEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - Creating a new Base";
    }
}