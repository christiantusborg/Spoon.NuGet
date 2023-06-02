using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1GetAllEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - GetAll a new Base";
    }
}