namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Advanced;

using Core.Presentation;

public class AdvancedCreateEndpointV1Summary : IEndpointSummary 
{
    public string GetEndpointSummary()
    {
        return "Overwrite - Creating a new Base";
    }
}