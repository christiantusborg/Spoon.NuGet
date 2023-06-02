using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1UpdateEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - Update a new Base";
    }
}