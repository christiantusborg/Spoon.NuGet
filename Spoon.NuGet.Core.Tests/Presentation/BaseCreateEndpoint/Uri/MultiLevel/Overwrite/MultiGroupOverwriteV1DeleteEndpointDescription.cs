using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1DeleteEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - Delete new Base";
    }
}