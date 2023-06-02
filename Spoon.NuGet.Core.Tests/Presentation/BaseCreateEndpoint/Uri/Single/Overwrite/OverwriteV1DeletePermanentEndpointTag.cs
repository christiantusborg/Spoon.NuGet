using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1DeletePermanentEndpointTag :IOverwriteInformation
{
    public string Get()
    {
        return "somethingTag";
    }
}