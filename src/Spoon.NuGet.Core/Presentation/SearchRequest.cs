namespace Spoon.NuGet.Core.Presentation;

using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Web;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Default implementation for a Search Request
/// </summary>
public class SearchRequest : BaseRequestWithSearchAndPagination
{
    /// <summary>
    /// Include Soft Deleted
    /// </summary>
    public bool IncludeDeletedSoft { get; set; }
    /// <summary>
    /// Used for parsing as query string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="provider"></param>
    /// <param name="objResult"></param>
    /// <returns></returns>
    public static bool TryParse(string? value, IFormatProvider? provider, out SearchRequest? objResult)
    {
        //var trimmedValue = value?.TrimStart('(').TrimEnd(')');
        //var segments = trimmedValue?.Split(',',
        //        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //value.Split();
        //if (segments == null)
        //{
        objResult = new SearchRequest()
        {
            IncludeDeletedSoft = false,
            Page = 1,
            PageLength = 100
        };
        //}
        objResult = GetFromQueryString<SearchRequest>(value ?? "", objResult);
        return true;
    }
    /// <summary>
    /// Used for parsing as query string.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static ValueTask<SearchRequest?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        var objResult = new SearchRequest()
        {
            IncludeDeletedSoft = false,
            Page = 1,
            PageLength = 100,
            SortField = null,
        };
        objResult = GetFromQueryString<SearchRequest>(context.Request.QueryString.Value, objResult);
        return ValueTask.FromResult<SearchRequest?>(objResult);
    }

    /// <summary>
    /// Used for parsing as query string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="queryString"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T GetFromQueryString<T>(string? queryString, T obj) where T : new()
    {
        if (queryString == null)
            return new T();
        NameValueCollection query = HttpUtility.ParseQueryString(queryString);
        if (obj == null)
            obj = new T();
        var properties = typeof(T).GetProperties(); // to get all properties from Class(Object)  
        foreach (var property in properties)
        {
            var valueAsString = query.AllKeys.Where(a => a == property.Name);
            if (valueAsString.Any())
            {
                object? value = Parse(property.PropertyType, query[property.Name]); // parse data types  
                if (value == null)
                    continue;

                property.SetValue(obj, value, null); //set values to properties.  
            }
        }
        return obj;
    }
    
    /// <summary>
    /// Used for parsing as query string. 
    /// </summary>
    /// <param name="dataType"></param>
    /// <param name="valueToConvert"></param>
    /// <returns></returns>
    public static object? Parse(Type? dataType, string? valueToConvert)
    {
        if (dataType == null)
            return valueToConvert;
        TypeConverter obj = TypeDescriptor.GetConverter(dataType);
        object? value = valueToConvert == null ? null : obj.ConvertFromString(null, CultureInfo.InvariantCulture, valueToConvert);
        return value;
    }
}
