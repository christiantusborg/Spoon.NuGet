using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1GetEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Get a new Base";
    }
}