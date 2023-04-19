namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.Validation.Assistants;

using FluentValidation.Results;

/// <summary>
///  Interface ISupportAssistant.
/// </summary>
public interface ISupportAssistant
{
    /// <summary>
    ///  Inform support.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="failuresValidate"></param>
    /// <typeparam name="TRequest"></typeparam>
    void InformSupport<TRequest>(TRequest request, List<ValidationFailure> failuresValidate);
}