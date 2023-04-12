namespace Spoon.NuGet.Mediator.PipelineBehaviors.Validation.Options;

using Assistants;


/// <summary>
///  Class ValidationPipelineOptions.
/// </summary>
public class ValidationPipelineOptions
{
    public ValidationPipelineAssistantOptions ValidationPipelineAssistantOptions { get; }
    public SupportAssistantOptions SupportAssistantOptions { get; }
    
    public ValidationPipelineOptions()
    {
        ValidationPipelineAssistantOptions = new ValidationPipelineAssistantOptions();
        this.SupportAssistantOptions = new SupportAssistantOptions();
    }
}