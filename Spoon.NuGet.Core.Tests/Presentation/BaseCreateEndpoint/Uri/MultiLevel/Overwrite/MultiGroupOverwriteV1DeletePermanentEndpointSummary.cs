using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1DeletePermanentEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - DeletePermanent a new Base";
    }
}