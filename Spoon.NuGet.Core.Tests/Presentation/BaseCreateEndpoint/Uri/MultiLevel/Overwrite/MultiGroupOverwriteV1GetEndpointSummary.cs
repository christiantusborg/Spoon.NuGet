using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1GetEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - Get a new Base";
    }
}