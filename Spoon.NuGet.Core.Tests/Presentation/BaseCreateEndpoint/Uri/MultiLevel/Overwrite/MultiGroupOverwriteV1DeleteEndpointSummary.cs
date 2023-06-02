using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1DeleteEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Delete a new Base";
    }
}