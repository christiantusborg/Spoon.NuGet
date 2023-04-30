namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.MessageQueue.Attributes;

using System.ComponentModel.DataAnnotations;

/// <summary>
///  Class MessageQueueExcludeAttribute
/// </summary>
/// <summary>
/// Class PermissionExcludeAttribute. This class cannot be inherited.
/// Implements the <see cref="System.Attribute" />.
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Class)]
public class MessageQueueExcludeAttribute : Attribute
{
    private readonly string _argument;

    /// <summary>
    ///  Initializes a new instance of the <see cref="MessageQueueExcludeAttribute"/> class.
    /// </summary>
    /// <param name="argument"></param>
    public MessageQueueExcludeAttribute([Required] string argument)
    {
        this._argument = argument;
    }
}