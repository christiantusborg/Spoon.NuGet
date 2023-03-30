namespace Spoon.NuGet.Mediator;

using Interfaces.EventSourcing;

/// <summary>
/// Class MediatorBaseCommand.
/// Implements the <see cref="MediatorBase" />
/// Implements the <see cref="IPipelineBehaviorEventSourcing" />.
/// </summary>
/// <seealso cref="MediatorBase" />
/// <seealso cref="IPipelineBehaviorEventSourcing" />
public  abstract class MediatorBaseCommand : MediatorBase, IPipelineBehaviorEventSourcing
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediatorBaseCommand"/> class.
    /// </summary>
    /// <param name="command">The command.</param>
    public MediatorBaseCommand(Type command)
        : base(command)
    {
    }
}