using Spoon.NuGet.Core.Presentation;

namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;

public class MultiGroupOverwriteV1GetAllEndpointSummary : IOverwriteInformation 
{
    public string Get()
    {
        return "Overwrite Summary - GetAll a new Base";
    }
}