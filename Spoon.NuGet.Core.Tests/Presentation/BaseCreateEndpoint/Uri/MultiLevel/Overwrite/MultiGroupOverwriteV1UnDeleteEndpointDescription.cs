using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1UnDeleteEndpointDescription : IOverwriteInformation
{
    public string Get()
    {
        return "Overwrite Description - UnDelete a new Base";
    }
}