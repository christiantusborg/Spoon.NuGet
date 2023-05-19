namespace Spoon.NuGet.Core.Presentation;

using System.Text.RegularExpressions;

/// <summary>
///     Base class for an endpoint.
/// </summary>
public abstract partial class BaseEndpoint
{

    /// <summary>
    ///   Gets the endpoint information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointName()
    {
        return this.GetEndpointNameOverwrite();
    }
    /// <summary>
    ///     Gets the endpoint name.
    /// </summary>
    /// <returns></returns>
    private string GetEndpointNameAutomatic()
    {
        var input = GetType().Name;
        var information = GetEndpointInformation(input);
        
        var withoutLastWord = information.words[0];

        var wordJoinedWithoutLastWord = information.Version.ToLower() + "/" + withoutLastWord.ToLower();
        
        var result = information.words[1].ToLower() switch
        {
            "create" => wordJoinedWithoutLastWord,
            "get" when information.words.Length == 3 && information.words[^1].ToLower() == "all" => wordJoinedWithoutLastWord,
            "get" => $"{wordJoinedWithoutLastWord}/{{{information.words[^2].ToLower()}Id}}",
            _ => information.words[^2].ToLower() switch
            {
                // ReSharper disable once StringLiteralTypo
                "delete" when information.words.Length == 3 && information.words[^1].ToLower() == "permanent" => $"{wordJoinedWithoutLastWord}/{{{information.words[0].ToLower()}Id}}/permanent",
                "un" when information.words.Length == 3 && information.words[^1].ToLower() == "delete" => $"{wordJoinedWithoutLastWord}/{{{information.words[0].ToLower()}Id}}/undelete",
                _ => information.words[^1].ToLower() is "update" or "delete"
                    ? $"{wordJoinedWithoutLastWord}/{{{information.words[^2].ToLower()}Id}}"
                    : $"Unknown action: {string.Join(" ", information.words)}",
            },
        };
        return result;
    }

    /// <summary>
    ///     Gets the endpoint summary information.
    /// </summary>
    /// <returns></returns>
    private string GetEndpointNameOverwrite()
    {
        var input = GetType().Name;
        var information = GetEndpointInformation(input);

        var className = information.Name + "Endpoint" + information.Version + "Name";

        // Get all loaded assemblies
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // Search for the class in all assemblies
        var classType = assemblies
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == className && t.IsClass);

        var interfaceType = typeof(IEndpointName);
        if (classType is null && !interfaceType.IsAssignableFrom(classType))
            return this.GetEndpointNameAutomatic();


        var summaryClass = Activator.CreateInstance(classType)!;

        var result = ((IEndpointName)summaryClass).GetOverwriteEndpointName();
        return result;
    }    
    
    /// <summary>
    ///     Gets the endpoint summary information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointSummary()
    {
        var input = GetType().Name;
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
            return GetDefaultEndpointSummary();


        var summaryClass = Activator.CreateInstance(classType)!;

        var result = ((IEndpointSummary)summaryClass).GetEndpointSummary();
        return result;
    }

    private string GetDefaultEndpointSummary()
    {
        var input = GetType().Name;
        var description = new BaseEndpointSummary();
        return description.GetBaseEndpointSummary(input);
    }

    /// <summary>
    ///     Gets the endpoint description information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointDescription()
    {
        var input = GetType().Name;
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


        var summaryClass = Activator.CreateInstance(classType)!;

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
        var index = endpoint.IndexOf(endpointSuffix, StringComparison.Ordinal);

        // Extract the category name and version
        var name = endpoint[..index];
        var version = endpoint[(index + endpointSuffix.Length)..];


        // Split the string using regular expressions
        var words = MyRegex().Split(name);
        return (name, version, words);
    }

    [GeneratedRegex("(?<!^)(?=[A-Z])")]
    private static partial Regex MyRegex();
}