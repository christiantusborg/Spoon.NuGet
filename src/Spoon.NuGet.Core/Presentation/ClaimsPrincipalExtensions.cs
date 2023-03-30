namespace Spoon.NuGet.Core.Presentation;

using System.Security.Claims;

/// <summary>
/// Extensions ClaimsPrincipal
/// </summary>
public static class ClaimsPrincipalExtensions
{
    /// <summary>
    ///  Get UserID from ClaimsPrincipal->ClaimTypes.NameIdentifier
    /// </summary>
    /// <param name="principal"></param>
    /// <returns></returns>
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        var claim = principal?.FindFirst(ClaimTypes.NameIdentifier);
        return !Guid.TryParse(claim?.Value, out var userId) ? Guid.Empty : userId;
    }
}