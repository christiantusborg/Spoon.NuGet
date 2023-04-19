namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.Validation.Options;

/// <summary>
///  Class SupportAssistantOptions.
/// </summary>
public class SupportAssistantOptions
{
    /// <summary>
    ///  Config manual.
    /// </summary>
    public bool ConfigManual { get; set; } = false;
    /// <summary>
    ///  Use log interceptor.
    /// </summary>
    public bool UseLogInterceptor { get; set; } = true;
}