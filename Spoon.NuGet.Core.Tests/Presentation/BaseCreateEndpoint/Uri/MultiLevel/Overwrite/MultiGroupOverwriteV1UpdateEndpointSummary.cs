using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1UpdateEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Update a new Base";
    }
}