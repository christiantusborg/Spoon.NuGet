using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1DeletePermanentEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - DeletePermanent a new Base";
    }
}