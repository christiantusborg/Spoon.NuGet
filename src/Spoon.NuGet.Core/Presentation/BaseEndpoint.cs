namespace Spoon.NuGet.Core.Presentation;

using System.Text.RegularExpressions;

/// <summary>
///     Base class for an endpoint.
/// </summary>
public abstract class BaseEndpoint
{
    /// <summary>
    ///     Gets the endpoint name.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointName()
    {
        var input = this.GetType().Name;
        var information = GetEndpointInformation(input);

        var result = information.Version + "/" + string.Join("/", information.words);
        return result;
    }

    /// <summary>
    ///     Gets the endpoint summary information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointSummary()
    {
        var input = this.GetType().Name;
        var information = GetEndpointInformation(input);

        var className = information.Name + "Endpoint" + information.Version + "Summary";

        // Get all loaded assemblies
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Search for the class in all assemblies
        var classType = assemblies
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == className && t.IsClass);

        var interfaceType = typeof(IEndpointSummary);
        if (classType is null && !interfaceType.IsAssignableFrom(classType))
            return this.GetDefaultEndpointSummary();


        var summaryClass = Activator.CreateInstance(classType);

        if (summaryClass is null)
            return this.GetDefaultEndpointSummary();


        var result = ((IEndpointDescription)summaryClass).GetEndpointDescription();
        return result;
    }


    private string GetDefaultEndpointSummary()
    {
        var input = this.GetType().Name;
        var description = new BaseEndpointSummary();
        return description.GetBaseEndpointSummary(input);
    }

    /// <summary>
    ///     Gets the endpoint description information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointDescription()
    {
        var input = this.GetType().Name;
        var information = GetEndpointInformation(input);

        var className = information.Name + "Endpoint" + information.Version + "Description";

        // Get all loaded assemblies
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Search for the class in all assemblies
        var classType = assemblies
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == className && t.IsClass);

        var interfaceType = typeof(IEndpointDescription);
        if (classType is null && !interfaceType.IsAssignableFrom(classType))
            return this.GetDefaultEndpointDescription();


        var summaryClass = Activator.CreateInstance(classType);

        if (summaryClass is null)
            return this.GetDefaultEndpointDescription();


        var result = ((IEndpointDescription)summaryClass).GetEndpointDescription();
        return result;
    }

    private string GetDefaultEndpointDescription()
    {
        var input = this.GetType().Name;
        var description = new BaseEndpointDescription();
        return description.GetBaseEndpointDescription(input);
    }


    private static (string Name, string Version, string[] words) GetEndpointInformation(string endpoint)
    {
        var endpointSuffix = "Endpoint";

        // Find the index where the endpoint suffix starts
        var index = endpoint.IndexOf(endpointSuffix);

        // Extract the category name and version
        var name = endpoint.Substring(0, index);
        var version = endpoint.Substring(index + endpointSuffix.Length - 1).ToLower();


        // Split the string using regular expressions
        var words = Regex.Split(name.ToLower(), @"(?<!^)(?=[A-Z])");
        return (name, version, words);
    }
}