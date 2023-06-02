using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1UpdateEndpointTag : IOverwriteInformation 
{
    public string Get()
    {
        return "somethingTag";
    }
}