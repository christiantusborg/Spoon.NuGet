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
        var words = Regex.Split(categoryName, @"(?<!^)(?=[A-Z])");

        
        var result = words[1].ToLower() switch 
        {
            "create" => $"Creating a new {words[0]}",
            "get" when (words.Length == 3 && words[^1].ToLower() == "all") => $"Get {words[0]} by search criteria",
            "get" => $"Get a {words[0]} by id",
            // ReSharper disable once StringLiteralTypo
            "update" => $"Update a {words[0]} by id",
            "delete" when (words.Length == 3 && words[^1].ToLower() == "permanent") => $"Delete permanently a {words[0]} by id",
            "delete" => $"Delete a {words[0]} by id",
            "un" when (words.Length == 3 && words[^1].ToLower() == "delete") => $"Undelete a {words[0]} by id",
            _ => $"Unknown action: {string.Join(" ", words)}",
        };

        return result;
    }
        
}