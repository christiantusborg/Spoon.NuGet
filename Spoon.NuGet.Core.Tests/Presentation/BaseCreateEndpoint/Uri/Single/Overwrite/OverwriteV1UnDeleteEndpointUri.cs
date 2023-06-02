using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1UnDeleteEndpointUri : IOverwriteInformation
{
    public string Get()
    {
        return "v1/something/{advancedId}/undelete";
    }
}