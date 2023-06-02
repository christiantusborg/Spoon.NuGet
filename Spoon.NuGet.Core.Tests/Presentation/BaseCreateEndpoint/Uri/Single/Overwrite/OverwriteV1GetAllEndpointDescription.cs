using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

public class OverwriteV1GetAllEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - GetAll a new Base";
    }
}