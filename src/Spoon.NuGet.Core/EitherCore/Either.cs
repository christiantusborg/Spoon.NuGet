namespace Spoon.NuGet.Core.EitherCore;

using System.Diagnostics.CodeAnalysis;
using Contracts;
using Enums;
using Exceptions;

/// <summary>
///     Represents an Either object that can hold a value of type <typeparamref name="TSuccess" /> or an error value.
/// </summary>
/// <typeparam name="TSuccess">The type of the success value.</typeparam>
public class Either<TSuccess>
{
    /// <summary>
    ///     Gets the type of the Either object.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "We need use this reflection in Piplines")]
    internal readonly EitherEnum EitherEnum = EitherEnum.None;

    /// <summary>
    ///     Gets the faulted exception.
    /// </summary>
    private readonly EitherException? faulted;

    /// <summary>
    ///     Gets the success value.
    /// </summary>
    internal readonly TSuccess? success;

    /// <summary>
    ///     Gets the error message.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:Elements should be ordered by access", Justification = "We need use this reflection in Piplines")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "We need use this reflection in Piplines")]
    internal readonly EitherErrorMessage? EitherError;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Either{TSuccess}" /> class with a faulted exception.
    /// </summary>
    /// <param name="eitherException">The faulted exception.</param>
    public Either(EitherException eitherException)
    {
        this.faulted = eitherException;

        this.EitherEnum = EitherEnum.IsFaulted;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Either{TSuccess}" /> class with an error message.
    /// </summary>
    /// <param name="eitherError">The error message.</param>
    public Either(EitherErrorMessage eitherError)
    {
        this.EitherError = eitherError;
        this.EitherEnum = EitherEnum.EitherError;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Either{TSuccess}" /> class with a success value.
    /// </summary>
    /// <param name="success">The success value.</param>
    public Either(TSuccess? success)
    {
        this.success = success;
        this.EitherEnum = EitherEnum.Success;
    }

    /// <summary>
    ///     Matches the Either object with the provided functions.
    /// </summary>
    /// <typeparam name="T">The return type of the functions.</typeparam>
    /// <param name="faulted">The function to execute if the Either object is faulted.</param>
    /// <param name="success">The function to execute if the Either object contains a success value.</param>
    /// <returns>The result of executing the appropriate function based on the state of the Either object.</returns>
    public T Match<T>(Func<EitherException, T> faulted, Func<TSuccess, T> success)
    {
        return this.EitherEnum == EitherEnum.Success ? success(this.success!) : faulted(this.GetFaulted());
    }

    /// <summary>
    ///     Gets the faulted exception.
    /// </summary>
    /// <returns>The faulted exception.</returns>
    internal EitherException GetFaulted()
    {
        switch (this.EitherEnum)
        {
            case EitherEnum.IsFaulted:
                return this.faulted!;
            case EitherEnum.EitherError:
                if (this.EitherError is null)
                    throw new ArgumentNullException($"Getinge.NuGet.Core.EitherCore.Exceptions.ExceptionBase EitherError->IsNull");
                return new EitherException(
                    string.Empty,
                    this.EitherError.Value.Origin,
                    this.EitherError.Value.Message,
                    this.EitherError.Value.StatusCode);
            case EitherEnum.Success:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}