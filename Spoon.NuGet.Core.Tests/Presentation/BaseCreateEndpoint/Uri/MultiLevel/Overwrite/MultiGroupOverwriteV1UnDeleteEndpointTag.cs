using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1UnDeleteEndpointTag : IOverwriteInformation 
{
    public string Get()
    {
        return "somethingTag";
    }
}