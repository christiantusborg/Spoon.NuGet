namespace Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Advanced;

using Core.Presentation;

public class AdvancedCreateEndpointV1Description : IEndpointDescription
{
    public string GetEndpointDescription()
    {
        return "Overwrite Description - Creating a new Base";
    }
}