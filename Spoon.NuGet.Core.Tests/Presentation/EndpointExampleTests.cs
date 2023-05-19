namespace Spoon.NuGet.Core.Tests.Presentation;

using Core.Presentation;

public class EndpointExampleTests
{
    [Fact]
    public void ExampleGuid_ShouldBeValid()
    {
        // Arrange
        var expectedGuid = Guid.Parse("0a0b0c0d-1e2f-3a4b-5c6d-0a0b0c0d0e0f");

        // Act
        var actualGuid = EndpointExample.ExampleGuid;

        // Assert
        Assert.Equal(expectedGuid, actualGuid);
    }

    [Theory]
    [InlineData(false, "John")]
    [InlineData(true, "Jane")]
    public void GetFirstname_ShouldReturnCorrectValue(bool isFemale, string expectedFirstname)
    {
        // Act
        var actualFirstname = EndpointExample.GetFirstname(isFemale);

        // Assert
        Assert.Equal(expectedFirstname, actualFirstname);
    }

    [Fact]
    public void ExampleLastname_ShouldBeValid()
    {
        // Arrange
        var expectedLastname = "Doe";

        // Act
        var actualLastname = EndpointExample.ExampleLastname;

        // Assert
        Assert.Equal(expectedLastname, actualLastname);
    }
}