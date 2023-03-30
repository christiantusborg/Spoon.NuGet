namespace Spoon.NuGet.Mediator;

using MediatR;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Class MediatorRootController.
/// Implements the <see cref="ControllerBase" />.
/// </summary>
/// <seealso cref="ControllerBase" />
public abstract class MediatorRootController : ControllerBase
    {
    /// <summary>
    /// Gets the mediator.
    /// </summary>
    /// <value>The mediator.</value>
    /// <exception cref="System.InvalidOperationException">MediatorRootController->Mediator is null.</exception>
    protected IMediator Mediator =>
            (IMediator)this.HttpContext?.RequestServices?.GetService(typeof(IMediator)) ! ??
            throw new InvalidOperationException("MediatorRootController->Mediator is null");
    }
