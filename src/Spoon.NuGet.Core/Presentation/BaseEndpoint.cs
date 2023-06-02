using System.Reflection;
using System.Text.RegularExpressions;

namespace Spoon.NuGet.Core.Presentation;

/// <summary>
///     Base class for an endpoint.
/// </summary>
public abstract partial class BaseEndpoint
{
    /// <summary>
    ///     Gets the endpoint information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointName()
    {
        if (HasOverwriteEndpointInformation(GetType(), InformationType.Uri, out var overwriteEndpointInformation))
            return overwriteEndpointInformation!;

        var endpointName = GetEndpointInformation(GetType(), InformationType.Uri).Uri;
        return endpointName;
    }


    /// <summary>
    ///     Gets the endpoint summary information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointSummary()
    {
        if (HasOverwriteEndpointInformation(GetType(), InformationType.Summary, out var overwriteEndpointInformation))
            return overwriteEndpointInformation!;

        var endpointName = GetEndpointInformation(GetType(), InformationType.Summary);
        return endpointName.Uri;
    }

    /// <summary>
    ///     Gets the endpoint tag information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointTag()
    {
        if (HasOverwriteEndpointInformation(GetType(), InformationType.Tag, out var overwriteEndpointInformation))
            return overwriteEndpointInformation!;

        var endpointName = GetEndpointInformation(GetType(), InformationType.Tag);
        return endpointName.Uri;
    }

    /// <summary>
    ///     Gets the endpoint description information.
    /// </summary>
    /// <returns></returns>
    public string GetEndpointDescription()
    {
        if (HasOverwriteEndpointInformation(GetType(), InformationType.Description,
                out var overwriteEndpointInformation))
            return overwriteEndpointInformation!;

        var endpointName = GetEndpointInformation(GetType(), InformationType.Description);
        return endpointName.Uri;
    }

    private static bool HasOverwriteEndpointInformation(Type getType, InformationType informationType,
        out string? overwriteEndpointInformation)
    {
        var overwriteClassName = informationType switch
        {
            InformationType.Uri => "Uri",
            InformationType.Summary => "Summary",
            InformationType.Description => "Description",
            InformationType.Tag => "Tag",
            _ => throw new ArgumentOutOfRangeException(nameof(informationType), informationType, null)
        };

        var className = getType.Name + overwriteClassName;

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var classType = assemblies
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == className && t.IsClass);

        var interfaceType = typeof(IOverwriteInformation);
        if (classType is null && !interfaceType.IsAssignableFrom(classType))
        {
            overwriteEndpointInformation = null;
            return false;
        }

        var overwriteClass = (IOverwriteInformation)Activator.CreateInstance(classType)!;

        overwriteEndpointInformation = overwriteClass.Get();

        return true;
    }

    /// <summary>
    ///     Gets the endpoint summary information.
    /// </summary>
    /// <returns></returns>
    private static (string Name, string Version, string Uri) GetEndpointInformation(
        Type endpointType, InformationType informationType)
    {
        var endpoint = endpointType.Name;

        var words = MyRegex().Split(endpoint);

        // Extract the category name and version
        var endpointTypeName = words[^2];
        var version = words[^3];

        var parameter = GetEndpointParameter(endpointTypeName, endpointType);


        var result = informationType switch
        {
            InformationType.Uri => GetUri(endpointType, endpointTypeName, words, parameter),
            InformationType.Tag => GetTag(endpointType, endpointTypeName, words),
            InformationType.Summary => GetSummary(endpointType, endpointTypeName, words),
            InformationType.Description => GetDescription(endpointType, endpointTypeName, words),
            _ => $"Unknown action: {endpointType.Name}"
        };

        return (endpointTypeName, version, result);
    }

    private static string GetSummary(MemberInfo endpointType, string endpointTypeName, IReadOnlyList<string> words)
    {
        var summary = endpointTypeName.ToLower() switch
        {
            "create" => $"Creating a new {words[^4]}",
            "all" => $"Get {words[^5]} by search criteria",
            "get" => $"Get a {words[^4]} by id",
            "update" => $"Update a {words[^4]} by id",
            "permanent" => $"Permanent delete a {words[^5]} by id",
            "delete" when words.Count >= 3 && words[^3].ToLower() == "un" => $"UnDelete a {words[^5]} by id",
            "delete" => $"Delete a {words[^4]} by id",
            _ => $"Unknown action: {endpointType.Name}"
        };

        return summary;
    }

    private static string GetDescription(MemberInfo endpointType, string endpointTypeName, IReadOnlyList<string> words)
    {
        var description = endpointTypeName.ToLower() switch
        {
            "create" => $"Creating a new <i>{words[^4]}</i>",
            "all" => $"Get <i>{words[^5]}</i> by search criteria",
            "get" => $"Get a <i>{words[^4]}</i> by id",
            "update" => $"Update a <i>{words[^4]}</i> by id",
            "permanent" => $"Permanent delete a <i>{words[^5]}</i> by id",
            "delete" when words.Count >= 3 && words[^3].ToLower() == "un" => $"UnDelete a <i>{words[^5]}</i> by id",
            "delete" => $"Delete a <i>{words[^4]}</i> by id",
            _ => $"Unknown action: {endpointType.Name}"
        };

        return description;
    }


    private static string GetUri(MemberInfo endpointType, string endpointTypeName, IReadOnlyList<string> words,
        string parameter)
    {
        var uri = endpointTypeName.ToLower() switch
        {
            "create" => "/" + words[^3].ToLower() + "/" + string.Join("/", words.Take(words.Count - 3)).ToLower(),
            "all" => "/" + words[^4].ToLower() + "/" + string.Join("/", words.Take(words.Count - 4)).ToLower(),
            "get" => "/" + words[^3].ToLower() + "/" + string.Join("/", words.Take(words.Count - 3)).ToLower() +
                     $"/{{{parameter}}}",
            "update" => "/" + words[^3].ToLower() + "/" + string.Join("/", words.Take(words.Count - 3)).ToLower() +
                        $"/{{{parameter}}}",
            "permanent" => "/" + words[^4].ToLower() + "/" + string.Join("/", words.Take(words.Count - 4)).ToLower() +
                           $"/{{{parameter}}}" + "/permanent",
            "delete" when words.Count >= 3 && words[^3].ToLower() == "un" => "/" + words[^4].ToLower() + "/" +
                                                                             string.Join("/",
                                                                                     words.Take(words.Count - 4))
                                                                                 .ToLower() +
                                                                             $"/{{{parameter}}}/undelete",
            "delete" => "/" + words[^3].ToLower() + "/" + string.Join("/", words.Take(words.Count - 3)).ToLower() +
                        $"/{{{parameter}}}",
            _ => $"Unknown action: {endpointType.Name}"
        };
        return uri;
    }

    private static string GetTag(MemberInfo endpointType, string endpointTypeName, IReadOnlyList<string> words)
    {
        var tag = endpointTypeName.ToLower() switch
        {
            "create" => string.Join("/", words.Take(words.Count - 3)).ToLower(),
            "all" => string.Join("/", words.Take(words.Count - 4)).ToLower(),
            "get" => string.Join("/", words.Take(words.Count - 3)).ToLower(),
            "update" => string.Join("/", words.Take(words.Count - 3)).ToLower(),
            "permanent" => string.Join("/", words.Take(words.Count - 4)).ToLower(),
            "delete" when words.Count >= 3 && words[^3].ToLower() == "un" => string
                .Join("/", words.Take(words.Count - 4)).ToLower(),
            "delete" => string.Join("/", words.Take(words.Count - 3)).ToLower(),
            _ => $"Unknown action: {endpointType.Name}",
        };
        return tag;
    }

    private static string GetEndpointParameter(string endpointName, Type endpointType)
    {
        if (endpointName is "create" or "getall")
            return "";

        var methodInfo = endpointType.GetMethod("EndpointHandler", BindingFlags.NonPublic | BindingFlags.Instance);

        if (methodInfo is null)
            return $"Unknown action: {endpointType.Name}";

        var parameterInfos = methodInfo.GetParameters();

        var result = parameterInfos.FirstOrDefault()?.Name;

        return result ?? $"Unknown action: {endpointType.Name}";
    }

    [GeneratedRegex("(?<!^)(?=[A-Z])")]
    private static partial Regex MyRegex();
}