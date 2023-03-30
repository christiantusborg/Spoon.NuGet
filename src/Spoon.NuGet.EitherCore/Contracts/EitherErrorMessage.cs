namespace Spoon.NuGet.EitherCore.Contracts;

/// <summary>
///     Represents an error message that can either originate from the server or the client.
/// </summary>
public struct EitherErrorMessage
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EitherErrorMessage" /> struct.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="origin">The origin of the error message (either "server" or "client").</param>
    /// <param name="statusCode">The HTTP status code associated with the error.</param>
    public EitherErrorMessage(string message, string origin, int statusCode)
    {
        this.Message = message;
        this.Origin = origin;
        this.StatusCode = statusCode;
    }

    /// <summary>
    ///     Gets the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    ///     Gets the origin of the error message (either "server" or "client").
    /// </summary>
    public string Origin { get; }

    /// <summary>
    ///     Gets the HTTP status code associated with the error.
    /// </summary>
    public int StatusCode { get; }
}