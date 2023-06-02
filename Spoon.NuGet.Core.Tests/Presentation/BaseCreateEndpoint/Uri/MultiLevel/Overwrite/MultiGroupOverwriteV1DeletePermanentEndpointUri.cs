using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1DeletePermanentEndpointUri :IOverwriteInformation
{
    public string Get()
    {
        return "v1/something/{advancedId}/permanent";
    }
}