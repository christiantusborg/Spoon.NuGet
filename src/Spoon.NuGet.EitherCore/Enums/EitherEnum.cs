namespace Spoon.NuGet.EitherCore.Enums;

/// <summary>
///     Enumeration representing the possible outcomes of an Either instance.
/// </summary>
public enum EitherEnum
{
    /// <summary>
    ///     The Either instance represents a faulted state.
    /// </summary>
    IsFaulted,

    /// <summary>
    ///     The Either instance represents a successful state.
    /// </summary>
    Success,

    /// <summary>
    ///     The Either instance represents an error state.
    /// </summary>
    EitherError,

    /// <summary>
    ///     The Either instance is in its default state.
    /// </summary>
    None,
}