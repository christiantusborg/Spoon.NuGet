namespace Spoon.NuGet.Core.Tests.Presentation;

using Core.Presentation;

public class BaseSearchPresentationResponseTests
{
    [Fact]
    public void Constructor_InitializesProperties()
    {
        // Arrange
        var total = 10;
        var items = new List<string> { "Item1", "Item2", "Item3" };

        // Act
        var response = new BaseSearchPresentationResponse<string>
        {
            Total = total,
            Items = items
        };

        // Assert
        Assert.Equal(total, response.Total);
        Assert.Equal(items, response.Items);
    }

    [Fact]
    public void Items_DefaultValueIsNotNull()
    {
        // Arrange & Act
        var response = new BaseSearchPresentationResponse<string>();

        // Assert
        Assert.NotNull(response.Items);
    }
}