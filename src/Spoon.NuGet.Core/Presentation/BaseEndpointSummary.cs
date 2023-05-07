namespace Spoon.NuGet.Core.Presentation;

using System.Text.RegularExpressions;

/// <summary>
///  Represents the request to create a category.
/// </summary>
internal class BaseEndpointSummary
{
    /// <summary>
    ///  Gets the summary.
    /// </summary>
    internal string GetBaseEndpointSummary(string input) 
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
            "create" => $"Creating a new {words[^2]}",
            "get" => $"Get a {words[^2]} by id",
            // ReSharper disable once StringLiteralTypo
            "getall" => $"Get {words[^2]} by search criteria",
            "search" => $"Get {words[^2]} by search criteria",
            "update" => $"Update a {words[^2]} by id",
            "delete" => $"Delete a {words[^2]} by id",
            "undelete" => $"Undelete a {words[^2]} by id",
            // ReSharper disable once StringLiteralTypo
            "deletepermanently" => $"Delete permanently a {words[^2]} by id",
            _ => $"Unknown action: {string.Join(" ", words)}",
        };

        return result;
    }
        
}