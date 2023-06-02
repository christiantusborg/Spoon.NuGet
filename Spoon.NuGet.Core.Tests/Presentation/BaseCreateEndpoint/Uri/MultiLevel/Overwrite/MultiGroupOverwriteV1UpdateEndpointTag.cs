using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1UpdateEndpointTag : IOverwriteInformation 
{
    public string Get()
    {
        return "somethingTag";
    }
}