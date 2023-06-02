using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1CreateEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Creating a new Base";
    }
}