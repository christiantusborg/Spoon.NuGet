namespace Spoon.NuGet.Mediator.PipelineBehaviors.AuditLog;

/// <summary>
/// Class AuditLogMessage.
/// </summary>
public class AuditLogMessage 
{
    /// <summary>
    /// Gets or sets the event.
    /// </summary>
    /// <value>The event.</value>
    public string Event { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ip address.
    /// </summary>
    /// <value>The ip address.</value>
    public string IpAddress { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the location.
    /// </summary>
    /// <value>The location.</value>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date time.
    /// </summary>
    /// <value>The date time.</value>
    public DateTime DateTime { get; set; }
}