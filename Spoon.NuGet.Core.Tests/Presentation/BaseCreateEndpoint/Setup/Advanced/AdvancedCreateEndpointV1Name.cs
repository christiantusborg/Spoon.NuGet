namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Advanced;

using Spoon.NuGet.Core.Presentation;

public class AdvancedCreateEndpointV1Name : IEndpointName 
{
    public string GetOverwriteEndpointName()
    {
        return "v1/overwrite";
    }
}