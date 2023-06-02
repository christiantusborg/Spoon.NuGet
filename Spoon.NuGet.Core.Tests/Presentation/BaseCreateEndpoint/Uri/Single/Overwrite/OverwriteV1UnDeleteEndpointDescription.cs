using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1UnDeleteEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - UnDelete a new Base";
    }
}