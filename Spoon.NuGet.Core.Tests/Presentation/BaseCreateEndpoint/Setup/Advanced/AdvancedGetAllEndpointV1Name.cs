namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Advanced;

using Spoon.NuGet.Core.Presentation;

public class AdvancedGetAllEndpointV1Name : BaseEndpoint, IEndpointName 
{
    public string GetOverwriteEndpointName()
    {
        return "v1/overwrite";
    }
}