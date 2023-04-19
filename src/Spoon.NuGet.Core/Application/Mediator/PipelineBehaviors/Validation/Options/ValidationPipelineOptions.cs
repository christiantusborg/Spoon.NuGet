namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.Validation.Options;

/// <summary>
///  Class ValidationPipelineOptions.
/// </summary>
public class ValidationPipelineOptions
{
    /// <summary>
    ///  Gets the validation pipeline assistant options.
    /// </summary>
    public ValidationPipelineAssistantOptions ValidationPipelineAssistantOptions { get; }
    
    /// <summary>
    /// Gets the support assistant options.
    /// </summary>
    public SupportAssistantOptions SupportAssistantOptions { get; }
    
    /// <summary>
    ///  
    /// </summary>
    public ValidationPipelineOptions()
    {
        this.ValidationPipelineAssistantOptions = new ValidationPipelineAssistantOptions();
        this.SupportAssistantOptions = new SupportAssistantOptions();
    }
}