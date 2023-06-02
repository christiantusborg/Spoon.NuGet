using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1DeleteEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Delete a new Base";
    }
}