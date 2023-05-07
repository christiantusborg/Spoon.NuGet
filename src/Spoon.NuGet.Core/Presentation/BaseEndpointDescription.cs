namespace Spoon.NuGet.Core.Presentation;

using System.Text.RegularExpressions;

/// <summary>
///     Used for based for endpoint description, when you want to use the default implementation.
/// </summary>
internal class BaseEndpointDescription
{
    /// <summary>
    ///     Gets the description.
    /// </summary>
    internal string GetBaseEndpointDescription(string input)
    {
        var endpointSuffix = "Endpoint";

        // Find the index where the endpoint suffix starts
        var index = input.IndexOf(endpointSuffix, StringComparison.Ordinal);

        // Extract the category name and version
        var categoryName = input.Substring(0, index);
        var version = input[(index + endpointSuffix.Length - 1)..].ToLower();


        // Split the string using regular expressions
        var words = Regex.Split(categoryName.ToLower(), @"(?<!^)(?=[A-Z])");


        var result = words[^1].ToLower() switch
        {
            "create" => $"<h2>{input}</h2> <div>This endpoint can be used to creating a new <i>{words[^2]}</i></div>",
            "get" => $"<h2>{input}</h2> <div>Get a <i>{words[^2]}</i> by id</div>",
            // ReSharper disable once StringLiteralTypo
            "getall" => $"<h2>{input}</h2> <div>Get <i>{words[^2]}</i> by search criteria</div>",
            "search" => $"<h2>{input}</h2> <div>Get <i>{words[^2]}</i> by search criteria</div>",
            "update" => $"<h2>{input}</h2> <div>Update a <i>{words[^2]}</i> by id</div>",
            "delete" => $"<h2>{input}</h2> <div>Delete a <i>{words[^2]}</i> by id</div>",
            "undelete" => $"<h2>{input}</h2> <div>Undelete a <i>{words[^2]}</i> by id</div>",
            // ReSharper disable once StringLiteralTypo
            "deletepermanently" => $"<h2>{input}</h2> <div>Delete permanently a <i>{words[^2]}</i> by id</div>",
            _ => $"Unknown action: {string.Join(" ", words)}",
        };

        return result;
    }
}