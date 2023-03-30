namespace Spoon.NuGet.Mediator.Interfaces.WebHook;

/// <summary>
/// Interface IWebHookService.
/// </summary>
public interface IWebHookService
{
    /// <summary>
    /// Notifies the specified web hook.
    /// </summary>
    /// <param name="webHook">The web hook.</param>
    void Notify(WebHookMessage webHook);
}