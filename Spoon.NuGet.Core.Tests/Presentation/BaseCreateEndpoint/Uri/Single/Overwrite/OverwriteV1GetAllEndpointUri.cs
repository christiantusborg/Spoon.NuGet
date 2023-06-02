using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1GetAllEndpointUri : IOverwriteInformation
{
    public string Get()
    {
        return "v1/something";
    }
}