namespace Spoon.NuGet.Core.Presentation;

/// <summary>
///  Basic example of end examples.
/// </summary>
public static class EndpointExample
{
    /// <summary>
    ///  Gets the example Guid.
    /// </summary>
    public static Guid ExampleGuid { get; } = Guid.Parse("0a0b0c0d-1e2f-3a4b-5c6d-0a0b0c0d0e0f");
    
    /// <summary>
    ///  Gets the example Firstname.
    /// </summary>
    /// <param name="isFemale"></param>
    /// <returns></returns>
    public static string GetFirstname(bool isFemale = false)
    {
        return isFemale ? "Jane" : "John";
    }
    
    /// <summary>
    ///  Gets the example Lastname.
    /// </summary>
    public static string ExampleLastname { get; } = "Doe";
}