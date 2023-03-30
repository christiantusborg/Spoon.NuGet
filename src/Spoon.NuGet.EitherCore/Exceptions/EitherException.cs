namespace Spoon.NuGet.EitherCore.Exceptions;

/// <summary>
///     Represents an exception that is thrown when an Either object is in faulted state.
/// </summary>
public sealed class EitherException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EitherException" /> class with the specified command values, origin,
    ///     message, and status code.
    /// </summary>
    /// <param name="commandValues">The command values.</param>
    /// <param name="origin">The origin.</param>
    /// <param name="message">The message.</param>
    /// <param name="statusCode">The status code.</param>
    public EitherException(object commandValues, string origin, string message, int statusCode)
        : base(origin + "_" + message)
    {
        this.Data.Add("Command", commandValues.GetType().Name);
        this.Data.Add("CommandValues", commandValues);
        this.Data.Add("Origin", origin.Replace(".", "_"));
        this.Data.Add("HttpStatusCode", statusCode);
        this.Data.Add("Message", message);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EitherException" /> class with the specified command values, origin,
    ///     message, status code, and generic dictionary.
    /// </summary>
    /// <param name="commandValues">The command values.</param>
    /// <param name="origin">The origin.</param>
    /// <param name="message">The message.</param>
    /// <param name="statusCode">The status code.</param>
    /// <param name="generic">The generic dictionary.</param>
    public EitherException(object commandValues, string origin, string message, int statusCode, Dictionary<string, object> generic)
        : base(origin + "_" + message)
    {
        this.Data.Add("Command", commandValues.GetType().Name);
        this.Data.Add("CommandValues", commandValues);
        this.Data.Add("Origin", origin.Replace(".", "_"));
        this.Data.Add("HttpStatusCode", statusCode);
        this.Data.Add("Message", message);

        foreach (var item in generic)
        {
            this.Data.Add(item.Key, item.Value);
        }
    }
}