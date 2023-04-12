namespace Spoon.NuGet.Mediator.PipelineBehaviors.Validation.Assistants;

using FluentValidation.Results;

public class SupportAssistant : ISupportAssistant
{
    public void InformSupport<TRequest>(TRequest request, List<ValidationFailure> failuresValidate)
    {
        return;
    }
}