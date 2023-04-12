namespace Spoon.NuGet.Mediator.PipelineBehaviors.Validation.Assistants;

using FluentValidation.Results;
using MediatR;

public interface ISupportAssistant
{
    void InformSupport<TRequest>(TRequest request, List<ValidationFailure> failuresValidate);
}