using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1CreateEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Creating a new Base";
    }
}