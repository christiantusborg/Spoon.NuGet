namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog.Attributes;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Class PermissionExcludeAttribute. This class cannot be inherited.
/// Implements the <see cref="System.Attribute" />.
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Class)]
public sealed class AuditLogExcludeAttribute : Attribute
{
    /// <summary>
    /// The explanation.
    /// </summary>
    private readonly string _explanation;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditLogExcludeAttribute"/> class.
    /// </summary>
    /// <param name="explanation">The explanation.</param>
    public AuditLogExcludeAttribute([Required] string explanation)
    {
        this._explanation = explanation;
    }
}
