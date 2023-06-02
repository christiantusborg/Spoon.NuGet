using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1UnDeleteEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - UnDelete a new Base";
    }
}