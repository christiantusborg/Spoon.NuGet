namespace Spoon.NuGet.Mediator;

/// <summary>
/// Class MediatorBaseQuery.
/// Implements the <see cref="MediatorBase" />.
/// </summary>
/// <seealso cref="MediatorBase" />
public abstract class MediatorBaseQuery : MediatorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatorBaseQuery"/> class.
    /// </summary>
    /// <param name="command">The command.</param>
    public MediatorBaseQuery(Type command)
        : base(command)
    {
    }
}