namespace Spoon.NuGet.Core.EitherCore.Helpers;

using System.Diagnostics;
using Contracts;
using Enums;

/// <summary>
///     Provides helper methods for creating <see cref="Either{T}" /> instances with pre-defined error messages and HTTP
///     status codes.
/// </summary>
/// <typeparam name="T">The type of the success value in the <see cref="Either{T}" /> instance.</typeparam>
public static class EitherHelper<T>
{
    /// <summary>
    ///     Creates an <see cref="Either{T}" /> instance representing an entity not found error with a pre-defined error
    ///     message and HTTP status code.
    /// </summary>
    /// <param name="entity">The type of the entity that was not found.</param>
    /// <returns>An <see cref="Either{T}" /> instance representing an entity not found error.</returns>
    public static Either<T> EntityNotFound(Type entity)
    {
        return Create($"Entity_{entity.Name}_NotFound", BaseHttpStatusCodes.Status404NotFound);
    }

    /// <summary>
    ///     Creates an <see cref="Either{T}" /> instance representing an entity already exists error with a pre-defined error
    ///     message and HTTP status code.
    /// </summary>
    /// <param name="entity">The type of the entity that already exists.</param>
    /// <returns>An <see cref="Either{T}" /> instance representing an entity already exists error.</returns>
    public static Either<T> EntityAlreadyExists(Type entity)
    {
        return Create($"Entity_{entity.Name}_AlreadyExists", BaseHttpStatusCodes.Status409Conflict);
    }

    /// <summary>
    ///     Creates an <see cref="Either{T}" /> instance representing an administrator role required error with a pre-defined
    ///     error message and HTTP status code.
    /// </summary>
    /// <param name="entity">The type of the entity for which the administrator role is required.</param>
    /// <returns>An <see cref="Either{T}" /> instance representing an administrator role required error.</returns>
    public static Either<T> AdministratorRoleRequired(Type entity)
    {
        return Create($"AdministratorRoleRequired_{entity.Name}", BaseHttpStatusCodes.Status401Unauthorized);
    }

    /// <summary>
    ///     Creates an <see cref="Either{T}" /> instance representing a bad permissions error with a pre-defined error message
    ///     and HTTP status code.
    /// </summary>
    /// <param name="entity">The type of the entity for which the permissions are bad.</param>
    /// <returns>An <see cref="Either{T}" /> instance representing a bad permissions error.</returns>
    public static Either<T> BadPermissions(Type entity)
    {
        return Create($"BadPermissions_{entity.Name}", BaseHttpStatusCodes.Status403Forbidden);
    }

    /// <summary>
    ///     Creates an <see cref="Either{T}" /> instance representing an error with the specified error message and HTTP status
    ///     code.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="statusCodes">The HTTP status code for the error.</param>
    /// <returns>An <see cref="Either{T}" /> instance representing the error.</returns>
    public static Either<T> Create(string message, int statusCodes = BaseHttpStatusCodes.Status400BadRequest)
    {
        var callingMethod = new StackTrace()?.GetFrame(2)?.GetMethod()?.DeclaringType?.DeclaringType?.FullName ?? "Unknown";

        var eitherError = new EitherErrorMessage(message, callingMethod, statusCodes);
        var either = new Either<T>(eitherError);

        return either;
    }
}