using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1UpdateEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Update a new Base";
    }
}