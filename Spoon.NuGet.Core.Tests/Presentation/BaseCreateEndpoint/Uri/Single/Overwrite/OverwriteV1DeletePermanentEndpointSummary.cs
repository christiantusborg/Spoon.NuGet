using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1DeletePermanentEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - DeletePermanent a new Base";
    }
}