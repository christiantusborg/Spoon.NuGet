using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1DeletePermanentEndpointUri :IOverwriteInformation
{
    public string Get()
    {
        return "v1/something/{advancedId}/permanent";
    }
}