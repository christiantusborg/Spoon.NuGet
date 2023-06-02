using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1DeleteEndpointUri : IOverwriteInformation
{
    public string Get()
    {
        return "v1/something/{advancedId}";
    }
}