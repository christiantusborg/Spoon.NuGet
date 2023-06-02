using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1GetEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - Get a new Base";
    }
}