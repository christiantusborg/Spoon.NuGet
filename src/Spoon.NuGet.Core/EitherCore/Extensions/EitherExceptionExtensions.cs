namespace Spoon.NuGet.Core.EitherCore.Extensions;

using System.Collections;
using System.Dynamic;
using Exceptions;

/// <summary>
///     Provides extension methods for working with <see cref="EitherException" /> instances.
/// </summary>
public static class EitherExceptionExtensions
{
    /// <summary>
    ///     Converts the specified <see cref="EitherException" /> instance to an <see cref="ICollection{T}" /> of
    ///     <see cref="KeyValuePair{TKey, TValue}" /> objects.
    /// </summary>
    /// <param name="eitherException">The <see cref="EitherException" /> instance to convert.</param>
    /// <returns>
    ///     An <see cref="ICollection{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> objects containing the data from
    ///     the <paramref name="eitherException" />.
    /// </returns>
    public static ICollection<KeyValuePair<string, object>> ToICollection(this EitherException eitherException)
    {
        var expandoObjCollection = ExpandoObjCollection(eitherException);
        return expandoObjCollection;
    }

    /// <summary>
    ///     Gets an <see cref="ICollection{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> objects representing the data
    ///     contained in the specified <see cref="EitherException" /> instance.
    /// </summary>
    /// <param name="eitherException">The <see cref="EitherException" /> instance to retrieve the data from.</param>
    /// <returns>
    ///     An <see cref="ICollection{T}" /> of <see cref="KeyValuePair{TKey, TValue}" /> objects containing the data from
    ///     the <paramref name="eitherException" />.
    /// </returns>
    public static ICollection<KeyValuePair<string, object>> ExpandoObjCollection(this EitherException eitherException)
    {
        var expandoObj = new ExpandoObject();
        var expandoObjCollection = expandoObj as ICollection<KeyValuePair<string, object>>;
        foreach (var data in eitherException.Data)
        {
            var value = (DictionaryEntry)data;
            var key = (string)value.Key;
            expandoObjCollection.Add(new KeyValuePair<string, object>(key, value.Value!));
        }

        return expandoObjCollection;
    }
}